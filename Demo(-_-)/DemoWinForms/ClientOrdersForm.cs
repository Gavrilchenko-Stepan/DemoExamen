using DemoLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoProject
{
    public partial class ClientOrdersForm : Form
    {
        public ClientOrdersForm()
        {
            InitializeComponent();
        }

        public void SetOrder(Order order)
        {
            /// Д.З. Сделать масштабирование колонок таблицы по размеру окна
            /// Добавить строку Итого
            /// По цене: средняя цена, по стоимости - общая сумма, остальные - прочерки
            OrdersTable.DataSource = null;
            var records = order.GetRecords();
            if (records.Count > 0)
            {
                // Создаем DataTable и добавляем все записи + строку итогов
                DataTable table = new DataTable();

                // Добавляем колонки
                table.Columns.Add("Товар");
                table.Columns.Add("Дата заказа");
                table.Columns.Add("Цена", typeof(double));
                table.Columns.Add("Количество", typeof(int));
                table.Columns.Add("Стоимость", typeof(double));

                // Добавляем основные записи
                foreach (var record in records)
                {
                    table.Rows.Add(
                        record.NameProduct,
                        record.SaleDate.ToString("dd.MM.yyyy"),
                        record.Price,
                        record.Count,
                        record.Cost
                    );
                }

                // Вычисляем итоги
                double totalCost = records.Sum(r => r.Cost);
                double avgPrice = records.Average(r => r.Price);
                int totalCount = records.Sum(r => r.Count);

                // Добавляем строку итогов
                table.Rows.Add(
                    "ИТОГО:",
                    "—",
                    Math.Round(avgPrice, 2),
                    totalCount,
                    Math.Round(totalCost, 2)
                );
                OrdersTable.DataSource = table;
            }
        }
    }
}
