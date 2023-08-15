

using AdoNetLib;
using System.Data;

internal class Program
{
    private static void Main(string[] args)
    {
        var connection = new MainConnection();
        var result = connection.ConnectAsync();

        var data = new DataTable();

        if (result.Result)
        {
            Console.WriteLine("Подключение выполнено");

            var db = new DbExecutor(connection);

            var tableName = "NetworkUser";

            Console.WriteLine("Получаем данные из таблицы " + tableName);

            data = db.SelectAll(tableName);

            Console.WriteLine("Отключаем БД");
            connection.DisconnectAsync();
        }
        else
        {
            Console.WriteLine("Ошибка подключения");
        }
    }
}