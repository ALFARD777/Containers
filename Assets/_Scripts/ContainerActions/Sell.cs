using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Sell : MonoBehaviour
{
    public RandomSpawn RandomSpawn;
    public Text Name;
    public Text Cost;
    public GameObject SellMenu;
    public GameObject NoPlaceMenu;
    [HideInInspector] public string carName;
    [HideInInspector] public string carCost;
    [HideInInspector] public int carIntCost;
    public void StartSell()
    {
        StartCoroutine(ContinueSell());
    }
    private IEnumerator ContinueSell()
    {
        yield return new WaitForSeconds(3);
        switch (RandomSpawn.droppedCar.name.Replace("(Clone)", ""))
        {
            case "Trash":
                carName = "Мусор";
                carIntCost = 1;
                break;
            // EUROPEAN
            case "Bus":
                carName = "Автобус";
                carIntCost = 40;
                break;
            case "Car blue":
                carName = "Синий автомобиль";
                carIntCost = 16;
                break;
            case "Car red":
                carName = "Красный автомобиль";
                carIntCost = 16;
                break;
            case "Car yellow":
                carName = "Желтый автомобиль";
                carIntCost = 16;
                break;
            case "Medium":
                carName = "Средний автомобиль";
                carIntCost = 55;
                break;
            case "Minivan":
                carName = "Минивэн";
                carIntCost = 60;
                break;
            case "Muscle":
                carName = "Мускл";
                carIntCost = 65;
                break;
            case "Police":
                carName = "Мусорская";
                carIntCost = 59;
                break;
            case "Sedan":
                carName = "Ноу-нейм седан";
                carIntCost = 50;
                break;
            case "Small":
                carName = "Маленький автомобиль";
                carIntCost = 42;
                break;
            case "Taxi":
                carName = "Такси";
                carIntCost = 61;
                break;
            // AMERICAN
            case "Dodge":
                carName = "Додж";
                carIntCost = 40;
                break;
            case "Formula":
                carName = "Формула-1";
                carIntCost = 45;
                break;
            case "Impala":
                carName = "Импала";
                carIntCost = 55;
                break;
            case "Jeep":
                carName = "Джип";
                carIntCost = 9;
                break;
            // DUBAI
            case "Bumblbee blue":
                carName = "Синий Бамблби";
                carIntCost = 70;
                break;
            case "Bumblbee gray":
                carName = "Серый Бамблби";
                carIntCost = 70;
                break;
            case "Bumblbee purple":
                carName = "Фиолетовый Бамблби";
                carIntCost = 70;
                break;
            case "Bumblbee red":
                carName = "Красный Бамблби";
                carIntCost = 70;
                break;
            case "Bumblbee yellow":
                carName = "Желтый Бамблби";
                carIntCost = 80;
                break;
            case "Ghostemane":
                carName = "Гостемане";
                carIntCost = 130;
                break;
            case "Lambargabar":
                carName = "Ламбаргабар";
                carIntCost = 160;
                break;
            case "Maseratti":
                carName = "Мазератти";
                carIntCost = 150;
                break;
            // JAPAN
            case "Cadillac":
                carName = "Кадиллак";
                carIntCost = 90;
                break;
            case "Grand Cheroke":
                carName = "Гранд Чироке";
                carIntCost = 60;
                break;
            case "Nissan":
                carName = "Ниссан";
                carIntCost = 120;
                break;
            case "Zhuk":
                carName = "Жук";
                carIntCost = 30;
                break;
            // SOVIET
            case "Buhanka":
                carName = "Буханка";
                carIntCost = 60;
                break;
            case "gz21_ blue Variant":
            case "gz21_ green Variant":
            case "gz21_ lightblue Variant":
            case "gz21_ purple Variant":
            case "gz21_ red Variant":
            case "gz21_ sand Variant":
            case "gz21_ white Variant":
            case "gz21_ yellow Variant":
            case "gz21_ black Variant":
            case "gz21_ gray Variant":
                carName = "ГАЗ-21";
                carIntCost = 10;
                break;
            case "gz24_ blue Variant":
            case "gz24_ green Variant":
            case "gz24_ lightblue Variant":
            case "gz24_ purple Variant":
            case "gz24_ red Variant":
            case "gz24_ sand Variant":
            case "gz24_ white Variant":
            case "gz24_ yellow Variant":
            case "gz24_ black Variant":
            case "gz24_ gray Variant":
                carName = "ГАЗ-24";
                carIntCost = 11;
                break;
            case "Truck":
                carName = "Тягач";
                carIntCost = 39;
                break;
            case "VAZ":
                carName = "Просто ВАЗ";
                carIntCost = 22;
                break;
            case "Volga":
                carName = "Волга";
                carIntCost = 23;
                break;
            case "vz01_ blue Variant":
            case "vz01_ green Variant":
            case "vz01_ lightblue Variant":
            case "vz01_ purple Variant":
            case "vz01_ red Variant":
            case "vz01_ sand Variant":
            case "vz01_ white Variant":
            case "vz01_ yellow Variant":
            case "vz01_ black Variant":
            case "vz01_ gray Variant":
                carName = "ВАЗ-2101";
                carIntCost = 11;
                break;
            case "vz02_ blue Variant":
            case "vz02_ green Variant":
            case "vz02_ lightblue Variant":
            case "vz02_ purple Variant":
            case "vz02_ red Variant":
            case "vz02_ sand Variant":
            case "vz02_ white Variant":
            case "vz02_ yellow Variant":
            case "vz02_ black Variant":
            case "vz02_ gray Variant":
                carName = "ВАЗ-2102";
                carIntCost = 10;
                break;
            case "vz03_ blue Variant":
            case "vz03_ green Variant":
            case "vz03_ lightblue Variant":
            case "vz03_ purple Variant":
            case "vz03_ red Variant":
            case "vz03_ sand Variant":
            case "vz03_ white Variant":
            case "vz03_ yellow Variant":
            case "vz03_ black Variant":
            case "vz03_ gray Variant":
                carName = "ВАЗ-2103";
                carIntCost = 10;
                break;
            case "vz04_ blue Variant":
            case "vz04_ green Variant":
            case "vz04_ lightblue Variant":
            case "vz04_ purple Variant":
            case "vz04_ red Variant":
            case "vz04_ sand Variant":
            case "vz04_ white Variant":
            case "vz04_ yellow Variant":
            case "vz04_ black Variant":
            case "vz04_ gray Variant":
                carName = "ВАЗ-2104";
                carIntCost = 14;
                break;
            case "vz05_ blue Variant":
            case "vz05_ green Variant":
            case "vz05_ lightblue Variant":
            case "vz05_ purple Variant":
            case "vz05_ red Variant":
            case "vz05_ sand Variant":
            case "vz05_ white Variant":
            case "vz05_ yellow Variant":
            case "vz05_ black Variant":
            case "vz05_ gray Variant":
                carName = "ВАЗ-2105";
                carIntCost = 12;
                break;
            case "vz05r_ blue Variant":
            case "vz05r_ green Variant":
            case "vz05r_ lightblue Variant":
            case "vz05r_ purple Variant":
            case "vz05r_ red Variant":
            case "vz05r_ sand Variant":
            case "vz05r_ white Variant":
            case "vz05r_ yellow Variant":
            case "vz05r_ black Variant":
            case "vz05r_ gray Variant":
                carName = "ВАЗ-2105";
                carIntCost = 13;
                break;
            case "vz06_ blue Variant":
            case "vz06_ green Variant":
            case "vz06_ lightblue Variant":
            case "vz06_ purple Variant":
            case "vz06_ red Variant":
            case "vz06_ sand Variant":
            case "vz06_ white Variant":
            case "vz06_ yellow Variant":
            case "vz06_ black Variant":
            case "vz06_ gray Variant":
                carName = "ВАЗ-2106";
                carIntCost = 14;
                break;
            case "vz07_ blue Variant":
            case "vz07_ green Variant":
            case "vz07_ lightblue Variant":
            case "vz07_ purple Variant":
            case "vz07_ red Variant":
            case "vz07_ sand Variant":
            case "vz07_ white Variant":
            case "vz07_ yellow Variant":
            case "vz07_ black Variant":
            case "vz07_ gray Variant":
                carName = "ВАЗ-2107";
                carIntCost = 15;
                break;
            case "vz08_ blue Variant":
            case "vz08_ green Variant":
            case "vz08_ lightblue Variant":
            case "vz08_ purple Variant":
            case "vz08_ red Variant":
            case "vz08_ sand Variant":
            case "vz08_ white Variant":
            case "vz08_ yellow Variant":
            case "vz08_black Variant":
            case "vz08_ gray Variant":
                carName = "ВАЗ-2108";
                carIntCost = 16;
                break;
            case "vz09_ blue Variant":
            case "vz09_ green Variant":
            case "vz09_ lightblue Variant":
            case "vz09_ purple Variant":
            case "vz09_ red Variant":
            case "vz09_ sand Variant":
            case "vz09_ white Variant":
            case "vz09_ yellow Variant":
            case "vz09_ black Variant":
            case "vz09_ gray Variant":
                carName = "ВАЗ-2109";
                carIntCost = 17;
                break;
            case "vz21_ blue Variant":
            case "vz21_ green Variant":
            case "vz21_ lightblue Variant":
            case "vz21_ purple Variant":
            case "vz21_ red Variant":
            case "vz21_ sand Variant":
            case "vz21_ white Variant":
            case "vz21_ yellow Variant":
            case "vz21_ black Variant":
            case "vz21_ gray Variant":
                carName = "Нива 4х4";
                carIntCost = 18;
                break;
            case "vz31_ blue Variant":
            case "vz31_ green Variant":
            case "vz31_ lightblue Variant":
            case "vz31_ purple Variant":
            case "vz31_ red Variant":
            case "vz31_ sand Variant":
            case "vz31_ white Variant":
            case "vz31_ yellow Variant":
            case "vz31_ black Variant":
            case "vz31_ gray Variant":
                carName = "Нива 4х4";
                carIntCost = 18;
                break;
            case "vz099_ blue Variant":
            case "vz099_ green Variant":
            case "vz099_ lightblue Variant":
            case "vz099_ purple Variant":
            case "vz099_ red Variant":
            case "vz099_ sand Variant":
            case "vz099_ white Variant":
            case "vz099_ yellow Variant":
            case "vz099_ black Variant":
            case "vz099_ gray Variant":
                carName = "ВАЗ-21099";
                carIntCost = 18;
                break;
            default:
                carName = RandomSpawn.droppedCar.name.Replace("(Clone)", "");
                carIntCost = 0;
                break;
        }
        carIntCost *= 100000;
        carCost = carIntCost.ToString("N0", CultureInfo.InvariantCulture).Replace(",", ".") + "$";
        Name.text = carName;
        Cost.text = carCost;
        SellMenu.SetActive(true);
        foreach (var cont in RunOpen.contList)
        {
            cont[0].transform.parent.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void SellCar()
    {
        RandomSpawn.RunOpen.Init.AddBalance(carIntCost);
        CloseDoors();
    }
    public void TakeCar()
    {
        try
        {
            if (Parking.playerCarsStrings.Count >= 15 || !Parking.visited)
            {
                NoPlaceMenu.SetActive(true);
                return;
            }
        }
        catch
        {
            NoPlaceMenu.SetActive(true);
            return;
        }
        Parking.playerCarsStrings.Add(RandomSpawn.droppedCar.name.Replace("(Clone)", ""));
        Debug.Log(RandomSpawn.droppedCar.name.Replace("(Clone)", ""));
        CloseDoors();
    }
    private void CloseDoors()
    {
        for (int i = 0; i < RunOpen.contList[RandomSpawn.RunOpen.containerToOpen].Count; i++)
        {
            if (RunOpen.contList[RandomSpawn.RunOpen.containerToOpen][i].activeSelf)
            {
                GameObject doors = RunOpen.contList[RandomSpawn.RunOpen.containerToOpen][i].transform.Find("Doors").gameObject;
                doors.GetComponent<Animator>().SetTrigger("Close");
                StartCoroutine(ClosingContainerAndSpawnNew(i));
                break;
            }
        }
    }
    private IEnumerator ClosingContainerAndSpawnNew(int i)
    {
        yield return new WaitForSeconds(3f);
        Destroy(RandomSpawn.droppedCar);
        RunOpen.contList[RandomSpawn.RunOpen.containerToOpen][i].SetActive(false);
        RandomSpawn.RunOpen.colliders.SetActive(false);
        int containerToRespawn = RandomSpawn.RunOpen.containerToOpen;
        StartCoroutine(SpawnNewContainer(containerToRespawn));
    }
    private IEnumerator SpawnNewContainer(int containerToRespawn)
    {
        yield return new WaitForSeconds(Random.Range(5, 30));
        switch (containerToRespawn)
        {
            case 0:
                RandomSpawn.RunOpen.Init.RandomFirst();
                break;
            case 1:
                RandomSpawn.RunOpen.Init.RandomSecond();
                break;
            case 2:
                RandomSpawn.RunOpen.Init.RandomThird();
                break;
            case 3:
                RandomSpawn.RunOpen.Init.RandomFourth();
                break;
            case 4:
                RandomSpawn.RunOpen.Init.RandomFifth();
                break;
        }
    }
}
