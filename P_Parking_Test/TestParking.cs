using System.Runtime.InteropServices.Marshalling;
using P_Parking_App;

namespace P_Parking_Test
{

    [TestClass]
    public sealed class TestParking
    {
        
        [TestMethod]
        public void CheckLicensePlate_ActuallyInThePark()
        {
            //Arrange
            String licensePlate = "VD-092663";
            Parking parking1 = new Parking(20);
            parking1.CarList.Add(new Voiture(licensePlate));
            parking1.ParkingPlace[5] = new Place(parking1.CarList[parking1.CarList.Count - 1]);
            int waitedResult = 2;

            //Act
            int result = parking1.CheckLicensePlate(licensePlate);
            
            //Assert
            Assert.AreEqual(result, waitedResult);

        }
        [TestMethod]
        public void CheckLicensePlateNotInThePark()
        {
            //Arrange
            String licensePlate = "VD-092663";
            Parking parking1 = new Parking(20);
            parking1.CarList.Add(new Voiture("VD-099263"));
            parking1.ParkingPlace[5] = new Place(parking1.CarList[parking1.CarList.Count - 1]);
            int waitedResult = 1;

            //Act
            int result = parking1.CheckLicensePlate(licensePlate);

            //Assert
            Assert.AreEqual(result, waitedResult);

        }
        [TestMethod]
        public void CheckLicensePlateWrong()
        {
            //Arrange
            String licensePlate = "VD-0926";
            Parking parking1 = new Parking(20);
            parking1.CarList.Add(new Voiture("VD-099263"));
            parking1.ParkingPlace[5] = new Place(parking1.CarList[parking1.CarList.Count - 1]);
            int waitedResult = 0;

            //Act
            int result = parking1.CheckLicensePlate(licensePlate);

            //Assert
            Assert.AreEqual(result, waitedResult);

        }

    }
}
