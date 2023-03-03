using Source.Models;

DataTransfer data = new DataTransfer();

    Thread th1 = new Thread(() => data.transferFromAToB(100));
    Thread th2 = new Thread(() => data.transferFromBToA(100));

    th1.Start();
    th2.Start();

    Console.ReadLine();
