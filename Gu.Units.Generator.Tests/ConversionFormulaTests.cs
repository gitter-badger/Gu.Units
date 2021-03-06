﻿namespace Gu.Units.Generator.Tests
{
    using NUnit.Framework;

    public class ConversionFormulaTests
    {
        private MockSettings _settings;
        [SetUp]
        public void SetUp()
        {
            _settings = new MockSettings();
        }

        [Test]
        public void TrivialConversion()
        {
            var conversionFormula = new ConversionFormula(_settings.Metres)
            {
                ConversionFactor = 1
            };
            Assert.AreEqual("Metres", conversionFormula.ToSi);
            Assert.AreEqual("Metres", conversionFormula.FromSi);
        }

        [Test]
        public void FactorConversion()
        {
            var conversionFormula = new ConversionFormula(_settings.Metres)
            {
                ConversionFactor = 1
            };
            Assert.AreEqual("Metres", conversionFormula.ToSi);
            Assert.AreEqual("Metres", conversionFormula.FromSi);
        }
    }
}
