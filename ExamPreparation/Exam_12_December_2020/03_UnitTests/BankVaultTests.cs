using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    [TestFixture]
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkProperly()
        {
            BankVault bankVault = new BankVault();

            IReadOnlyDictionary<string, Item> vaultCells = new Dictionary<string, Item>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            CollectionAssert.AreEqual(vaultCells, bankVault.VaultCells);
        }


        [Test]
        public void AddItemMethodShouldWorkProperly()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd = new Item("George", "1");

            string result = bankVault.AddItem("A1", itemToAdd);

            Assert.AreEqual("Item:1 saved successfully!", result);
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenCellIsInvalid()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd = new Item("George", "1");

            Assert.That(() => { 
                string result = bankVault.AddItem("A5", itemToAdd);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenCellIsAlreadyTaken()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd1 = new Item("George", "1");
            Item itemToAdd2 = new Item("Lyubo", "2");

            bankVault.AddItem("A1", itemToAdd1);

            Assert.That(() => {
                string result = bankVault.AddItem("A1", itemToAdd2);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell is already taken!"));

        }

        [Test]
        public void AddItemMethodShouldThrowExceptionWhenItemExists()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd = new Item("George", "1");

            bankVault.AddItem("A1", itemToAdd);

            Assert.That(() => {
                string result = bankVault.AddItem("A2", itemToAdd);
            }, Throws.InvalidOperationException.With.Message.EqualTo("Item is already in cell!"));

        }

        [Test]
        public void RemoveItemMethodShouldWorkProperly()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd = new Item("George", "1");

            bankVault.AddItem("A1", itemToAdd);

            string result = bankVault.RemoveItem("A1", itemToAdd);

            Assert.AreEqual("Remove item:1 successfully!", result);
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionWhenCellIsInvalid()
        {
            BankVault bankVault = new BankVault();

            Item itemToAdd = new Item("George", "1");

            bankVault.AddItem("A1", itemToAdd);

            Assert.That(() => {
                string result = bankVault.RemoveItem("A5", itemToAdd);
            }, Throws.ArgumentException.With.Message.EqualTo("Cell doesn't exists!"));
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionWhenItemIsInvalid()
        {
            BankVault bankVault = new BankVault();

            Item itemtoRemove1 = new Item("George", "1");
            Item itemToRemove2 = new Item("Lyubo", "2");

            bankVault.AddItem("A1", itemtoRemove1);

            Assert.That(() => {
                string result = bankVault.RemoveItem("A1", itemToRemove2);
            }, Throws.ArgumentException.With.Message.EqualTo("Item in that cell doesn't exists!"));
        }
    }
}