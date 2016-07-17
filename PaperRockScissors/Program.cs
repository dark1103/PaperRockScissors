using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PaperRockScissors.Server_Form;

namespace PaperRockScissors
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0 && args[0] == "-client")
            {
                Application.Run(new Form1());
            }
            else
            {
                Server server = new Server();
                //---
                File.Copy(Assembly.GetExecutingAssembly().Location, Environment.CurrentDirectory + @"/client.exe", true);
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + @"/client.exe", "-client");
                Application.Run(new Server_Form());
            }
        }
    }
    enum ServerMessageType { NamesList, Winner, Text, Begin, Reset }
    enum ClientMessageType { ChangeName, Ready, Choise, Disconnect }
    enum Symbol { Paper, Rock, Scissors, Fuck, Fig, Gun, Goat, Bottle }
    class Server
    {
        public const int gameTime = 10000;
        public const int gunCooldown = 5;
        public const int bottleCooldown = 3;
        private bool inGame = false;
        public Task listenerTask;
        public Server()
        {
            listenerTask = new Task(Listen);
            listenerTask.Start();
        }
        List<ClientOnServer> clients = new List<ClientOnServer>();
        List<ClientOnServer> players = new List<ClientOnServer>();
        void Listen()
        {
            TcpListener listener = TcpListener.Create(7777);
            listener.Start();
            while (true)
            {
                clients.Add(new ClientOnServer(listener.AcceptTcpClient(), this));
                Log(clients.Last().Tcp.Client.LocalEndPoint.ToString() + " connected");
            }
        }
        public void SendNameList()
        {
            Log("Names send");
            string names = string.Join(";", clients.Select(s => s.Name).ToArray());
            byte[] nameBytes = Client.TextEncoder.GetBytes(names);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                memoryStream.WriteByte((byte)ServerMessageType.NamesList);
                memoryStream.Write(nameBytes, 0, nameBytes.Length);
                foreach (var i in clients)
                {
                    memoryStream.WriteTo(i.Stream);
                }
            }
        }
        public void Reset()
        {
            Log("Reset");
            players = new List<ClientOnServer>(clients);
            clients.ForEach(c => c.Write(CreateEmptyMessage(ServerMessageType.Reset)));
        }
        public static MemoryStream StringToStream(ServerMessageType type, string message)
        {
            byte[] nameBytes = Client.TextEncoder.GetBytes(message);
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.WriteByte((byte)type);
            memoryStream.Write(nameBytes, 0, nameBytes.Length);
            return memoryStream;
        }
        public byte[] CreateMessage(ServerMessageType type, string message)
        {
            List<byte> data = new List<byte>(Client.TextEncoder.GetBytes(message));
            data.Insert(0, (byte)type);
            return data.ToArray();
        }
        public byte[] CreateEmptyMessage(ServerMessageType type)
        {
            return new byte[1] { (byte)type };
        }
        public void SendToAll(byte[] message)
        {
            clients.ForEach(c => c.Stream.Write(message, 0, message.Length));
        }
        public void OnPlayerDisconnected(ClientOnServer client)
        {
            Log(client.Name + " disconected");
            client.Tcp.Close();
            clients.Remove(client);
            Reset();
            SendNameList();
        }
        public void TryBegin()
        {
            if (players.Count <= 1) players = clients;

            if (!inGame && players.Count > 1 && players.FirstOrDefault(c => c.ready == false) == null)
            {
                Task task = new Task(BeginGame);
                task.Start();
            }
        }
        private void BeginGame()
        {
            Log("Game begin");
            inGame = true;
            clients.ForEach(c => { c.Write(CreateEmptyMessage(ServerMessageType.Begin)); c.ready = false; c.symbol = Symbol.Rock; });
            System.Threading.Thread.Sleep(gameTime);

            var winners = GetWinners().Players;
            string namesString = String.Join(";", winners.Select(w => w.Name));
            clients.ForEach(c => c.Write(CreateMessage(ServerMessageType.Winner, namesString)));

            players = winners;
            if (players.Count <= 1)
            {
                Reset();
            }

            inGame = false;
        }
        private class Groups: IDictionary<Symbol, List<ClientOnServer>>
        {
            private Dictionary<Symbol, List<ClientOnServer>> core;
            public Groups()
            {
                core = new Dictionary<Symbol, List<ClientOnServer>>();
            }
            public Groups(IEnumerable<ClientOnServer> players)
            {
                core = new Dictionary<Symbol, List<ClientOnServer>>();
                foreach (var p in players)
                {
                    Add(p.symbol, p);
                }
            }
            public Groups(Groups source)
            {
                core = new Dictionary<Symbol, List<ClientOnServer>>(source);
            }
            public Groups GetWithSymbols(params Symbol[] symbols)
            {
                Groups result = new Groups();
                foreach (var i in core)
                {
                    if (symbols.Contains(i.Key))
                    {
                        result.Add(i.Key, i.Value);
                    }
                }
                return result;
            }
            public void Add(Symbol key, ClientOnServer value)
            {
                if (core.ContainsKey(key))
                {
                    core[key].Add(value);
                }
                else
                {
                    core.Add(key, new List<ClientOnServer>() { value });
                }
            }
            public int ContainsKeys(Symbol[] key)
            {
                int value = 0;
                foreach (var i in key)
                {
                    if (ContainsKey(i))
                    {
                        value++;
                    }
                }
                return value;
            }
            public List<ClientOnServer> Players {
                get
                {
                    List<ClientOnServer> list = new List<ClientOnServer>();
                    foreach (var item in core.Values)
                    {
                        list.AddRange(item);
                    }
                    return list;
                }
            }
            #region interface
            public List<ClientOnServer> this[Symbol key]
            {
                get
                {
                    return ((IDictionary<Symbol, List<ClientOnServer>>)core)[key];
                }

                set
                {
                    ((IDictionary<Symbol, List<ClientOnServer>>)core)[key] = value;
                }
            }

            public int Count
            {
                get
                {
                    return ((IDictionary<Symbol, List<ClientOnServer>>)core).Count;
                }
            }

            public bool IsReadOnly
            {
                get
                {
                    return ((IDictionary<Symbol, List<ClientOnServer>>)core).IsReadOnly;
                }
            }

            public ICollection<Symbol> Keys
            {
                get
                {
                    return ((IDictionary<Symbol, List<ClientOnServer>>)core).Keys;
                }
            }

            public ICollection<List<ClientOnServer>> Values
            {
                get
                {
                    return ((IDictionary<Symbol, List<ClientOnServer>>)core).Values;
                }
            }

            public void Add(KeyValuePair<Symbol, List<ClientOnServer>> item)
            {
                ((IDictionary<Symbol, List<ClientOnServer>>)core).Add(item);
            }

            public void Add(Symbol key, List<ClientOnServer> value)
            {
                ((IDictionary<Symbol, List<ClientOnServer>>)core).Add(key, value);
            }

            public void Clear()
            {
                ((IDictionary<Symbol, List<ClientOnServer>>)core).Clear();
            }

            public bool Contains(KeyValuePair<Symbol, List<ClientOnServer>> item)
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).Contains(item);
            }

            public bool ContainsKey(Symbol key)
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).ContainsKey(key);
            }

            public void CopyTo(KeyValuePair<Symbol, List<ClientOnServer>>[] array, int arrayIndex)
            {
                ((IDictionary<Symbol, List<ClientOnServer>>)core).CopyTo(array, arrayIndex);
            }

            public IEnumerator<KeyValuePair<Symbol, List<ClientOnServer>>> GetEnumerator()
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).GetEnumerator();
            }

            public bool Remove(KeyValuePair<Symbol, List<ClientOnServer>> item)
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).Remove(item);
            }

            public bool Remove(Symbol key)
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).Remove(key);
            }

            public bool TryGetValue(Symbol key, out List<ClientOnServer> value)
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).TryGetValue(key, out value);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IDictionary<Symbol, List<ClientOnServer>>)core).GetEnumerator();
            }
            #endregion
        }
        private Groups GetWinners()
        {
            Groups groups = new Groups(players);

            Groups winners;

            if (groups.GetWithSymbols(Symbol.Gun).Count == 1)
            {
                winners = groups.GetWithSymbols(Symbol.Gun,Symbol.Goat);
            }
            else
            {
                winners = groups.GetWithSymbols(Symbol.Scissors, Symbol.Rock, Symbol.Paper, Symbol.Fuck, Symbol.Fig);
                WinerType result = GetNormalWinner(ref winners);
                if(result != WinerType.Default && winners.Players.Count > 1)
                {
                    winners = groups.GetWithSymbols(Symbol.Goat);
                }
            }
            if(groups.ContainsKey(Symbol.Bottle)) winners.Add(Symbol.Bottle, groups[Symbol.Bottle]);
            return winners;
        }
        enum WinerType { Default, None, Equal, Mix }
        private WinerType GetSimpleWinners(ref Groups list)
        {
            switch (list.ContainsKeys(new Symbol[]{ Symbol.Paper, Symbol.Rock, Symbol.Scissors }))
            {
                case 0:
                    return WinerType.None;
                break;
                case 1:
                    return WinerType.Equal;
                break;
                case 3:
                    return WinerType.Mix;
                break;
                default:
                if (!list.ContainsKey(Symbol.Paper))
                {
                    list.Remove(Symbol.Scissors);
                    return WinerType.Default;
                }
                else if (!list.ContainsKey(Symbol.Rock))
                {
                    list.Remove(Symbol.Paper);
                    return WinerType.Default;
                }
                else if (!list.ContainsKey(Symbol.Scissors))
                {
                    list.Remove(Symbol.Rock);
                    return WinerType.Default;
                }
                else
                {
                    throw new Exception("Error");
                }
                break;
            }
        }
        private WinerType GetNormalWinner(ref Groups list)
        {
            Groups simpleWinners = new Groups(list.GetWithSymbols(Symbol.Scissors,Symbol.Rock,Symbol.Paper));
            WinerType simpleResult = GetSimpleWinners(ref simpleWinners);
            if (list.ContainsKey(Symbol.Fuck))
            {
                if (list.ContainsKey(Symbol.Fig))
                {
                    if(simpleResult == WinerType.None)
                    {
                        list = list.GetWithSymbols(Symbol.Fig);
                        return WinerType.Default;
                    }
                    else
                    {
                        return WinerType.Mix;
                    }
                }
                else
                {
                    list = list.GetWithSymbols(Symbol.Fuck);
                    return WinerType.Default;
                }
            }
            else if (list.ContainsKey(Symbol.Fig))
            {
                if(simpleResult == WinerType.None)
                {
                    list = list.GetWithSymbols(Symbol.Fig);
                    return WinerType.Default;
                }
                else
                {
                    list = simpleWinners;
                    return WinerType.Default;
                }
            }
            else
            {
                list = simpleWinners;
                return simpleResult;
            }
        }
    }
    class ClientOnServer : Client
    {
        public Server server;
        public bool ready = false;
        public ClientOnServer(TcpClient client, Server server) : base(client)
        {
            this.server = server;
        }
        protected override void Listen()
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                int length;
                try
                {
                    length = Stream.Read(buffer, 0, buffer.Length);
                }
                catch       
                {
                    server.OnPlayerDisconnected(this);
                    return;
                }
                ClientMessageType type = (ClientMessageType)buffer[0];
                switch (type)
                {
                    case ClientMessageType.ChangeName:
                        Name = TextEncoder.GetString(buffer, 1, length - 1);
                        server.SendNameList();
                        Console.WriteLine(Name);
                    break;
                    case ClientMessageType.Choise:
                        symbol = (Symbol)buffer[1];
                        Log(Name + " set symbol " + symbol.ToString());
                    break;
                    case ClientMessageType.Ready:
                        ready = true;
                        server.TryBegin();
                    break;
                    case ClientMessageType.Disconnect:
                        server.OnPlayerDisconnected(this);
                    break;
                }
            }
        }
    }
    class ClientOnSide : Client
    {
        public ClientOnSide(TcpClient client, string name) : base(client)
        {
            this.Name = name;
            SendName();
        }
        public static ClientOnSide Create (string host, int port , string name)
        {
            TcpClient client = new TcpClient();
            client.Connect(host, port);
            if (client.Connected)
            {
                ClientOnSide newClient = new ClientOnSide(client, name);
                return newClient;
            }
            else
            {
                throw new Exception("Connection error");
            }
        }

        public Action OnDisconnect;
        public Action<string[]> OnPlayersListChanged;
        public Action OnBegin;
        public Action OnReset;
        public Action<List<string>> OnWinnersGet;
        protected override void Listen()
        {
            while (true)
            {
                byte[] buffer = new byte[2048];
                int length;

                try
                {
                    length = Stream.Read(buffer, 0, buffer.Length);
                }
                catch
                {
                    Disconnect();
                    return;
                }

                ServerMessageType type = (ServerMessageType)buffer[0];
                switch (type)
                {
                    case ServerMessageType.NamesList:
                        string names = TextEncoder.GetString(buffer, 1, length - 1);
                        OnPlayersListChanged?.Invoke(names.Split(';'));
                    break;

                    case ServerMessageType.Text:
                        string message = TextEncoder.GetString(buffer, 1, length - 1);
                        MessageBox.Show(message);
                    break;

                    case ServerMessageType.Winner:
                        List<string> winners = TextEncoder.GetString(buffer, 1, length - 1).Split(';').ToList();
                        OnWinnersGet?.Invoke(winners);

                    break;

                    case ServerMessageType.Reset:
                        OnReset?.Invoke();
                    break;
                    case ServerMessageType.Begin:
                        OnBegin?.Invoke();
                    break;
                }
            }
        }
        void SendName()
        {
            //List<byte> data = new List<byte>(TextEncoder.GetBytes(Name));
            //data.Insert(0, (byte)ClientMessageType.ChangeName);
            //Stream.Write(data.ToArray(), 0, data.Count);
            Write(CreateMessage(ClientMessageType.ChangeName, Name));
        }
        public void SendReady()
        {
            Write(CreateEmptyMessage(ClientMessageType.Ready));
        }
        public void SendSymbol(Symbol symbol)
        {
            this.symbol = symbol;
            byte[] data = { (byte)ClientMessageType.Choise, (byte)symbol };
            Stream.Write(data, 0, data.Length);
        }
        public void Disconnect()
        {
            if (Tcp.Connected)
            {
                Write(CreateEmptyMessage(ClientMessageType.Disconnect));
                Tcp.Close();
            }
            OnDisconnect?.Invoke();
        }
        public byte[] CreateMessage(ClientMessageType type, string message)
        {
            List<byte> data = new List<byte>(Client.TextEncoder.GetBytes(message));
            data.Insert(0, (byte)type);
            return data.ToArray();
        }
        public byte[] CreateEmptyMessage(ClientMessageType type)
        {
            return new byte[1] { (byte)type };
        }
    }
    abstract class Client
    {
        public Symbol symbol = Symbol.Paper;
        private Task listenerTask;
        public static Encoding TextEncoder { get { return Encoding.UTF8; } }
        public string Name { get; protected set; } = "Default";
        public TcpClient Tcp { get; protected set; }
        public NetworkStream Stream { get; private set; }
        public StreamReader reader { get; private set; }
        public StreamWriter writer { get; private set; }
        public Client(TcpClient client)
        {
            this.Tcp = client;
            Stream = client.GetStream();
            reader = new StreamReader(Stream);
            writer = new StreamWriter(Stream);

            listenerTask = new Task(Listen, TaskCreationOptions.LongRunning);
            listenerTask.Start();
        }
        public void Write(byte[] data)
        {
            Stream.Write(data, 0, data.Length);
        }
        protected abstract void Listen();
    }
}
