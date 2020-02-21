using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayerInterfaces;
using LogicLayer;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Jordan Lindo
    /// DATE: 2/6/2020
    /// CHECKED BY: Alex Diers
    /// 
    /// This is a unit test set for DepartmentManager.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    [TestClass]
    public class DepartmentManagerTests
    {
        private IDepartmentAccessor _departmentAccessor;


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test constructor DepartmentManager.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public DepartmentManagerTests()
        {
            _departmentAccessor = new FakeDepartmentAccessor();
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for retrieving all departments.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void RetrieveAllDepartmentsTest()
        {
            List<Department> departments;
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            departments = departmentManager.RetrieveAllDepartments();

            Assert.AreEqual(1, departments.Count);
        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for retrieve by id.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void RetrieveDepartmentById()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department()
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment;


            anotherDepartment = departmentManager.RetrieveDepartmentByID(department.DepartmentID);

            Assert.AreEqual(department.DepartmentID, anotherDepartment.DepartmentID);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for good values insert.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestGood()
        {
            string goodDepartmentId = "Good departmentId Test";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(goodDepartmentId, goodDescription);

            Assert.AreEqual(true, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for null id insert.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestBadNullId()
        {
            string badDepartmentId = null;
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(badDepartmentId, goodDescription);

            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/6/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for existing id insert.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestBadRepeatId()
        {
            string badDepartmentId = "Fake Department";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(badDepartmentId, goodDescription);

            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/16/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager too long ID.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongID()
        {
            string tooLong = "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970" +
                "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970" +
                "012345678910111213141516171819202122232425262728293031323334353637383940414243444546474849505152535455565758596061626364656667686970";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(tooLong, goodDescription);

            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/16/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager just too long ID.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongIDEdge()
        {
            string tooLong = "111111111111111111111111111111111111111111111111111";
            string goodDescription = "Good description Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(tooLong, goodDescription);

            Assert.AreEqual(false, result);

        }

        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/16/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager just too long description.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void AddDepartmentTestTooLongDescription()
        {
            string tooLong = "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "11111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111";
            string goodDepartmentId = "Good departmentId Test";
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            bool result = departmentManager.AddDepartment(goodDepartmentId, tooLong);

            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/15/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestDepartmentNotFound()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);

            Department missingDepartment = new Department
            {
                DepartmentID = "Missing",
                Description = "None"
            };
            Department newDepartment = new Department
            {
                DepartmentID = "Missing",
                Description = "Other"
            };
            bool result = departmentManager.EditDepartment(missingDepartment, newDepartment);

            Assert.AreEqual(false, result);
        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/15/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match to original id by new.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestNoMatchID()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department mismatchDepartment = new Department
            {
                DepartmentID = "firstDepartment",
                Description = "A Description"
            };
            Department otherDepartment = new Department
            {
                DepartmentID = "secondDepartment",
                Description = "A new Description"
            };

            bool result = departmentManager.EditDepartment(mismatchDepartment, otherDepartment);

            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/15/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager no match to existing description.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestNoMatchDescription()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Flake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/16/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager one char to long description.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestTooLongDescription()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "Fake Department",
                Description = "111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111" +
                "1111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111111"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);

        }


        /// <summary>
        /// NAME: Jordan Lindo
        /// DATE: 2/16/2020
        /// CHECKED BY: Alex Diers
        /// 
        /// This is a unit test for DepartmentManager one char to long id.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        [TestMethod]
        public void UpdateDepartmentTestTooLongID()
        {
            IDepartmentManager departmentManager = new DepartmentManager(_departmentAccessor);
            Department department = new Department
            {
                DepartmentID = "Fake Department",
                Description = "Fake Description"
            };
            Department anotherDepartment = new Department
            {
                DepartmentID = "111111111111111111111111111111111111111111111111111",
                Description = "Fake Description"
            };

            bool result = departmentManager.EditDepartment(department, anotherDepartment);
            Assert.AreEqual(false, result);

        }

    }
}
