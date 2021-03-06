// <copyright file="ServerTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaperRockScissors;

namespace PaperRockScissors.Tests
{
    /// <summary>Этот класс содержит параметризованные модульные тесты для Server</summary>
    [PexClass(typeof(Server))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class ServerTest
    {
    }
}
