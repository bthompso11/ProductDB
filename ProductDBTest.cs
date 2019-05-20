using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Data;
using System.Data.SqlClient;


namespace CustomerMaintenance
{
    [TestFixture]
    public class ProductDBTest
    {

        [SetUp]
        public void Setup()
        {
            Product p = new Product();
            p.ProductCode = "ZZZZ";
            p.Description = "Test Product";
            p.UnitPrice = 99.9M;
            p.OnHandQuantity = 2;

            if (ProductDB.GetProduct("ZZZZ     ") != null)
                ProductDB.DeleteProduct(p);
            else
                ProductDB.AddProduct(p);



        }

        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("2JST      ");
            Assert.AreEqual("2JST      ", p.ProductCode);
            Assert.AreEqual(6937, p.OnHandQuantity);
        }

        [Test]
        public void TestInsertProduct()
        {
            //Need to change ProductCode everytime test is run otherwise
            //it will give an error that primary key is not unique.
            Product p = new Product();
            p.ProductCode = "ZZZZ";
            p.Description = "Test Product";
            p.UnitPrice = 99.9M;
            p.OnHandQuantity = 2;

            //ProductDB.AddProduct(p);

           Product p1 = ProductDB.GetProduct("ZZZZ     ");
            Assert.AreEqual("ZZZZ      ", p1.ProductCode);
            Assert.AreEqual(2, p1.OnHandQuantity);

            

            
        }

        [Test]
        public void TestUpdateProduct()
        {
            //need to retrieve product from data base
            //either use clone or can use two variables
            //update values to change except for the ProductCode
            //Because ProductCode is what references the actual product and knows what to update.

            Product p = new Product();
            p.ProductCode = "ZZZ1";
            p.Description = "Test Product";
            p.UnitPrice = 99.9M;
            p.OnHandQuantity = 2;
            ProductDB.DeleteProduct(p);
            ProductDB.AddProduct(p);

           

           Product op = ProductDB.GetProduct("ZZZ1     ");
           Product np = ProductDB.GetProduct("ZZZ1     ");

            Assert.AreEqual(2, op.OnHandQuantity);
            Assert.AreEqual(2, np.OnHandQuantity);

            
            np.OnHandQuantity = 3;


            ProductDB.UpdateProduct(op, np);
            Product pp = ProductDB.GetProduct("ZZZ1     ");

            
           

            Assert.AreEqual(3, pp.OnHandQuantity);

            //np.Description = "Replaced Test Product";
            //np.UnitPrice = 00.0M;
            //np.OnHandQuantity = 3;

            //ProductDB.UpdateProduct(op, np);

            //Assert.AreEqual(3, op.OnHandQuantity);



            // My previous thoughts when I wasn't getting the product and expecting the 
            // method to change the values.

                    //Product op = new Product();
                    //op.ProductCode = "ZZZZ";
                    //op.Description = "Test Product";
                    //op.UnitPrice = 99.9M;
                    //op.OnHandQuantity = 2;

                    //Product np = new Product();
                    //np.ProductCode = "YYYY";
                    //np.Description = "Replaced Test Product";
                    //np.UnitPrice = 00.0M;
                    //np.OnHandQuantity = 3;

            
            //ProductDB.UpdateProduct(op, np);

            //Trying to test that the Product op was switched to the np values.
            //Does not appear to be working this way.

           // Assert.AreEqual("YYYY      ", op.ProductCode);
           
        }

        [Test]
        public void TestDeleteProduct()
        {

            //Product p = new Product();
            //p.ProductCode = "ZZZZ";
            //p.Description = "Delete Test Product";
            //p.UnitPrice = 11.1M;
            //p.OnHandQuantity = 4;

            //Already added the Product p
          // ProductDB.AddProduct(p);

            //Assert.AreEqual(4, p.OnHandQuantity);
         

            Product d = ProductDB.GetProduct("ZZZZ      ");

            Assert.AreEqual("ZZZZ      ", d.ProductCode);

            
            Assert.IsTrue(ProductDB.DeleteProduct(d));
            Assert.IsNull(ProductDB.GetProduct("ZZZZ      "));
           


            

                    

            

                    //Assert.AreEqual(null, d1.ProductCode);
                    //Assert.AreEqual(null, d1.OnHandQuantity);

           // Assert.Throws<SqlException>( () => ProductDB.GetProduct("QQQ2      "));

            // If it is working would I need to be testing for the exception??

           


        }
    }

}
