using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;

internal class Program
{
    /*
    static void Info(int value){
        Console.WriteLine($"Info: {value}");
    }
    static void Info(string value){
        Console.WriteLine($"Info: {value}");
    }
    */
    static void Info<T>(T value){
        Console.WriteLine($"Info: {value}");
    }
    private static void Main(string[]args)
    {
    Console.WriteLine("Hello, World!");


    Info(10);
    Info("Hello");
    Info<double>(20);

    var kv = new KeyValue<int,string>();
    kv.Key = 123;
    kv.Value ="Marek";
    kv.Info();

    string[] t =new string[2];
    t[0]="Marek";
    t[1]="Marucha";
    
    Console.WriteLine($"Lenght: {t.Length}");

    Console.WriteLine($"{t[0]} {t[1]}");

    var col = new MyCollection<string>();
    col.Add("Marek");
    col.Add("Marucha");
    col.Add("Korwin");
    for(int i =0; i<15; i++){
        col.Add($"Item: {i}");
    }
    Console.WriteLine($"Lenght: {col.lenght}");
    /*
    for(var i = 0; i<col.lenght; i++){
        Console.WriteLine($"{i}: {col[1]}");
    }
    */
       // Console.WriteLine($"Element 19: {col.Get(19)}");
       foreach(var item in col){
        Console.WriteLine(item);
       }
        var items = new MyItems<KeyValue>();
        var nitem = items.CreateNew();
    }
    
}
class KeyValue<TKey,TValue>{

    public TKey  Key;
    public TValue Value;
    public void Info(){
        Console.WriteLine($"{Key}: {Value}");
    }
}

class KeyValue<TKey> : KeyValue<TKey,string>{

}
class KeyValue : KeyValue<int,string>{

}
class MyItems<T> where T: new(){
    public T CreateNew(){
        return new T();    }
}
class MyCollection<T> where T : IComparable{
    T[] data;
    int Lenght;

    public MyCollection(int count = 10){
        data= new T[count];
        Lenght=0;
    }
    public void Add(T item){
        if(Lenght>=data.Length){
            //nowa tablica
            System.Console.WriteLine($"newlenght: {data.Length *2}");
            var newData = new T[data.Length * 2];
            Array.Copy(data,newData,data.Length);
            data = newData;
        }
        data[Lenght] = item;
        Lenght++;
    }
    public T Get(int index){
        if(index>=lenght){
            throw new IndexOutOfRangeException("Index poza rozmiarem kolekcji");
        }
        return data[index];
    }

    public T this[int index]{
        get{
            return Get(index);
        }
    }
    public int lenght{
        get{
            return Lenght;
        }
    }
    public IEnumerator<T> GetEnumerator(){
        for(var i=0; i<Lenght; i++){
            yield return data[1];
        }
    }
    public void Sort(){
        Array.Sort(data,0,lenght);
    }
}