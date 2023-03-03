namespace Source.Models;

public class DataTransfer
{
    private int a;
    private int b;

    private Object aLock = new Object();
    private Object bLock = new Object();

    public DataTransfer()
    {
        a = 1000;
        b = 1000;
    }

    #region Deadlock Code


    //public void transferFromAToB(int amount)
    //{
    //    lock (aLock)
    //    {
    //        Thread.Sleep(100);
    //        a = a - amount;

    //        lock (bLock)
    //        {
    //            Thread.Sleep(100);
    //            b = b + amount;
    //        }
    //    }

    //    Console.WriteLine(amount + " was transfered from A to B.");
    //}

    //public void transferFromBToA(int amount)
    //{
    //    lock (bLock)
    //    {
    //        Thread.Sleep(100);
    //        b = b - amount;

    //        lock (aLock)
    //        {
    //            Thread.Sleep(100);
    //            a = a + amount;
    //        }
    //    }

    //    Console.WriteLine(amount + " was transfered from B to A.");
    //}


    #endregion

    #region Resolved deadlock Code

    public void transferFromAToB(int amount)
    {
        lock (aLock)
        {
            Thread.Sleep(100);
            a = a - amount;

            lock (bLock)
            {
                Thread.Sleep(100);
                b = b + amount;
            }
        }
        Console.WriteLine(amount + " was transfered from A to B.");
    }

    public void transferFromBToA(int amount)
    {
        lock (aLock)
        {
            Thread.Sleep(100);
            a = a + amount;
            lock (bLock)
            {
                Thread.Sleep(100);
                b = b - amount;
            }
        }
        Console.WriteLine(amount + " was transfered from B to A.");
    }

    #endregion



    #region Deadlock and Resolved Explanation

    //Birinci biz Deadlock Code ye baxaq
    //Goruruk ki her iki transferde diger threaddeki transferin bitmeyine eht duyulur yeni
    //TransferAtoBde de biz locka->lockb edirik TransferBtoAda da eksini lockb->locka ediirik
    //2 thread de bir birini gozleyir ve proses bitmir deadlocka dusur


    //Resolved Deadlockda ise
    //TransferAtoBde de biz locka->lockb edirik TransferBtoAde de locka->lockb ediirik
    //artiq threadler bir birini gozlemir yeni locka lockb nin neticesini alir
    //cunku diger threadde lockb etmirik ona gore de deadlocka dusmur


    #endregion
}
