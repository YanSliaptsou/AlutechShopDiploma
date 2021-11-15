using AlutechShopDiploma.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlutechShopDiploma.Services
{
    public class GoodCharacteristicsGetter
    {
        public Dictionary<string,string> GetGoodCharacteristics(int goodID)
        {
            SqlWorker sqlWorker = new SqlWorker("Data Source=(LocalDb)\\MSSQLLocalDB;Database=aspnet-AlutechShopDiploma-20210330115616;Integrated Security=True");
            string tableNum = sqlWorker.SelectDataFromDB("SELECT TableID FROM Goods WHERE GoodID = " + goodID);
            string itemNum = sqlWorker.SelectDataFromDB("SELECT ItemID FROM Goods WHERE GoodID = " + goodID);

            Dictionary<string, string> characteristics = new Dictionary<string, string>();

            switch (tableNum)
            {
                case "1483152329": //AdditionalComplectations 
                    {
                        characteristics.Add("Вес/Weight, кг(kg).", sqlWorker.SelectDataFromDB("SELECT NetWeight FROM AdditionalComplectations WHERE AdditionalComplectationID = " + itemNum));

                        break;
                    }

                case "1515152443": //AlutechBarriers 
                    {
                        characteristics.Add("Интенсивность работы/Work intensity", sqlWorker.SelectDataFromDB("SELECT WorkIntensity FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));
                        characteristics.Add("Крутящий момент/Torque", sqlWorker.SelectDataFromDB("SELECT Torque FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));
                        characteristics.Add("Максимальное время открытия и закрытия/Maximum opening and closing times, c", sqlWorker.SelectDataFromDB("SELECT MaxTimeOpenClose FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));
                        characteristics.Add("Питание от электросети/Mains supply, В", sqlWorker.SelectDataFromDB("SELECT Voltage FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));
                        characteristics.Add("Степень защиты корпуса/Enclosure protection", sqlWorker.SelectDataFromDB("SELECT CorpProtectionDegree FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));
                        characteristics.Add("Ширина перекрываемого проезда/Closed passage width", sqlWorker.SelectDataFromDB("SELECT OverlappingWidth FROM AlutechBarriers WHERE AlutechBarrierID = " + itemNum));

                        break;
                    }

                case "1547152557": //ComunelloAccessories 
                    {
                        characteristics.Add("Габаритные размеры/Dimensions, м(m)", sqlWorker.SelectDataFromDB("SELECT GabariteSizes FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));
                        characteristics.Add("Дальность действия внутри помещения/Indoor range, м(m)", sqlWorker.SelectDataFromDB("SELECT IndoorLightLength FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));
                        characteristics.Add("Дальность действия в открытом пространстве/Range in open space, м(m)", sqlWorker.SelectDataFromDB("SELECT OutdoorLightLength FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));
                        characteristics.Add("Приемлимая рабочая температура/Acceptable operating temperature, °С", sqlWorker.SelectDataFromDB("SELECT TemperatureRange FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));
                        characteristics.Add("Напряжение питания/Supply voltage, B(V)", sqlWorker.SelectDataFromDB("SELECT Voltage FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));
                        characteristics.Add("Тип выходных контактов/Output contact type", sqlWorker.SelectDataFromDB("SELECT OutputContactsType FROM ComunelloAccessories WHERE ComunelloAccessoryID = " + itemNum));

                        break;
                    }

                case "1579152671": //ComunelloDriveUnits 
                    {
                        characteristics.Add("Интенсивность использования/Intensity of use", sqlWorker.SelectDataFromDB("SELECT UsageIntensity FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));
                        characteristics.Add("Максимальная высота ворот/Maximum gate height, м(m)", sqlWorker.SelectDataFromDB("SELECT MaxGatesHeight FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));
                        characteristics.Add("Максимальная площадь ворот/Maximum goal area, кв. м(sq.m.)", sqlWorker.SelectDataFromDB("SELECT MaxGatesSquare FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));
                        characteristics.Add("Максимальная скорость перемещения ворот/Maximum gate travel speed, мм/сек(mm/sec)", sqlWorker.SelectDataFromDB("SELECT MaxGatesSpeed FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));
                        characteristics.Add("Тяговое усилие/Tractive effort, H(N)", sqlWorker.SelectDataFromDB("SELECT TrativeEffort FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));
                        characteristics.Add("Электродвигатель/Electric motor, В(V)", sqlWorker.SelectDataFromDB("SELECT ElectricMotor FROM ComunelloDriveUnits WHERE ComunelloDriveUnitID = " + itemNum));

                        break;
                    }

                case "1739153241": //BusProfiles 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM BusProfiles WHERE BusProfileID = " + itemNum));
                        characteristics.Add("Материал/Material", sqlWorker.SelectDataFromDB("SELECT Material FROM BusProfiles WHERE BusProfileID = " + itemNum));

                        break;
                    }

                case "1771153355": //RollerAndSteelComplects 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM RollerAndSteelComplects WHERE RollerAndSteelComplectID = " + itemNum));

                        break;
                    }

                case "1803153469": //Brackets 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM Brackets WHERE BracketID = " + itemNum));
                        characteristics.Add("Норма поставки/Delivery rate, шт(pc)", sqlWorker.SelectDataFromDB("SELECT DeliveryRate FROM Brackets WHERE BracketID = " + itemNum));
                        characteristics.Add("Материал/Material", sqlWorker.SelectDataFromDB("SELECT Material FROM Brackets WHERE BracketID = " + itemNum));
                        characteristics.Add("Ось ролика/Roller axis", sqlWorker.SelectDataFromDB("SELECT RollerAxis FROM Brackets WHERE BracketID = " + itemNum));
                        characteristics.Add("Применение/Application", sqlWorker.SelectDataFromDB("SELECT Usage FROM Brackets WHERE BracketID = " + itemNum));

                        break;
                    }

                case "1835153583": //Clutches 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM Clutches WHERE ClutchID = " + itemNum));
                        characteristics.Add("Диаметр вала/Shaft diameter, мм(mm)", sqlWorker.SelectDataFromDB("SELECT ShaftDiameter FROM Clutches WHERE ClutchID = " + itemNum));
                        characteristics.Add("Материал/Material", sqlWorker.SelectDataFromDB("SELECT Material FROM Clutches WHERE ClutchID = " + itemNum));
                        characteristics.Add("Норма поставки/Delivery rate, шт(pc)", sqlWorker.SelectDataFromDB("SELECT DeliveryRate FROM Clutches WHERE ClutchID = " + itemNum));

                        break;
                    }

                case "1899153811": //GarageGateOperatorAnMotors 
                    {
                        characteristics.Add("Интенсивность использования/Usage intensity", sqlWorker.SelectDataFromDB("SELECT UsageIntensity FROM GarageGateOperatorAnMotors WHERE GarageGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Максимальная высота ворот/Maximum gate height, м(m)", sqlWorker.SelectDataFromDB("SELECT MaxGatesHeight FROM GarageGateOperatorAnMotors WHERE GarageGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Максимальная площадь ворот/Maximum goal area, м. кв.(sq. m.)", sqlWorker.SelectDataFromDB("SELECT MaxGatesSquare FROM GarageGateOperatorAnMotors WHERE GarageGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Тяговое усилие/Tractive effort, Н(N)", sqlWorker.SelectDataFromDB("SELECT TractiveEffort FROM GarageGateOperatorAnMotors WHERE GarageGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Электродвигатель/Electric motor, В(V)", sqlWorker.SelectDataFromDB("SELECT ElectricalMotor FROM GarageGateOperatorAnMotors WHERE GarageGateOperatorAnMotorsID = " + itemNum));

                        break;
                    }

                case "1931153925": //InsertAndSeals 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM InsertAndSeals WHERE InsertAndSealID = " + itemNum));
                        characteristics.Add("Материал/Material", sqlWorker.SelectDataFromDB("SELECT Material FROM InsertAndSeals WHERE InsertAndSealID = " + itemNum));
                        characteristics.Add("Норма поставки/Delivery rate, шт(pc)", sqlWorker.SelectDataFromDB("SELECT DeliveryRate FROM InsertAndSeals WHERE InsertAndSealID = " + itemNum));

                        break;
                    }

                case "1963154039": //Loops 
                    {
                        characteristics.Add("Вес/Weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT Weight FROM Loops WHERE LoopID = " + itemNum));
                        characteristics.Add("Материал/Material", sqlWorker.SelectDataFromDB("SELECT Material FROM Loops WHERE LoopID = " + itemNum));
                        characteristics.Add("Норма поставки/Delivery Rate, шт(pc)", sqlWorker.SelectDataFromDB("SELECT DeliveryRate FROM Loops WHERE LoopID = " + itemNum));

                        break;
                    }

                case "1995154153": //RecoilingGateOperatorAnMotors 
                    {
                        characteristics.Add("Рабочая температура/Work temperature, °С", sqlWorker.SelectDataFromDB("SELECT ApproprTemperature FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Интенсивность использования/Intensity of use, %", sqlWorker.SelectDataFromDB("SELECT UsageIntensity FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Максимальный крутящий момент/Maximum torque, Н*м(N*m)", sqlWorker.SelectDataFromDB("SELECT MaxTorque FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Питание/Voltage, В(V)", sqlWorker.SelectDataFromDB("SELECT Voltage FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Потребляемая мощность/Power consumption, Вт(Vt)", sqlWorker.SelectDataFromDB("SELECT Powerty FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));
                        characteristics.Add("Вес створки/Sash weight, кг(kg)", sqlWorker.SelectDataFromDB("SELECT SashWeight FROM RecoilingGateOperatorAnMotors WHERE RecoilingGateOperatorAnMotorsID = " + itemNum));

                        break;
                    }

                case "2027154267": //RollerAndRings 
                    {
                        characteristics.Add("Вес/Weight, кг(kg).", sqlWorker.SelectDataFromDB("SELECT Weight FROM RollerAndRings WHERE RollerAndRingID = " + itemNum));
                        characteristics.Add("Диаметр оси/Axle diameter, мм(mm)", sqlWorker.SelectDataFromDB("SELECT AxisDiameter FROM RollerAndRings WHERE RollerAndRingID = " + itemNum));
                        characteristics.Add("Длина ролика/Roller length, мм(mm)", sqlWorker.SelectDataFromDB("SELECT AxisLength FROM RollerAndRings WHERE RollerAndRingID = " + itemNum));
                        characteristics.Add("Норма поставки/Delivery rate, шт(pc)", sqlWorker.SelectDataFromDB("SELECT DeliveryRate FROM RollerAndRings WHERE RollerAndRingID = " + itemNum));
                        characteristics.Add("Ось ролика/Roller axis", sqlWorker.SelectDataFromDB("SELECT RollerAx FROM RollerAndRings WHERE RollerAndRingID = " + itemNum));

                        break;
                    }

            }
            return characteristics;
        }
    }
}