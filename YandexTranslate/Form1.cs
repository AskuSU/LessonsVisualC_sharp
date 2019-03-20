using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YandexTranslate
{
    public partial class Form1 : Form
    {
        ComboBox cb;

        public Form1()
        {
            InitializeComponent();

            comboBox1.SelectedItem = "Русский";

            comboBox2.SelectedItem = "Английский";

            cb = new ComboBox();

            #region Коллекция языков переводчика

            cb.Items.AddRange(new object[] {
            "Азербайджанский",
            "Азербайджанский",
            "Албанский",
            "Амхарский",
            "Английский",
            "Арабский",
            "Армянский",
            "Африкаанс",
            "Баскский",
            "Башкирский",
            "Белорусский",
            "Бенгальский",
            "Бирманский",
            "Болгарский",
            "Боснийский",
            "Валлийский",
            "Венгерский",
            "Вьетнамский",
            "Гаитянский",
            "Галисийский",
            "Горномарийский",
            "Греческий",
            "Грузинский",
            "Гуджарати",
            "Датский",
            "Иврит",
            "Идиш",
            "Индонезийский",
            "Ирландский",
            "Исландский",
            "Испанский",
            "Итальянский",
            "Казахский",
            "Каннада",
            "Каталанский",
            "Киргизский",
            "Китайский",
            "Корейский",
            "Коса β",
            "Кхмерский",
            "Лаосский β",
            "Латынь",
            "Латышский",
            "Литовский",
            "Люксембургский",
            "Македонский",
            "Малагасийский",
            "Малайский",
            "Малаялам",
            "Мальтийский",
            "Маори",
            "Маратхи",
            "Марийский",
            "Монгольский",
            "Немецкий",
            "Непальский",
            "Нидерландский",
            "Норвежский",
            "Панджаби",
            "Папьяменто",
            "Персидский",
            "Польский",
            "Португальский",
            "Румынский",
            "Русский",
            "Себуанский",
            "Сербский",
            "Сингальский",
            "Словацкий",
            "Словенский",
            "Суахили",
            "Сунданский",
            "Тагальский",
            "Таджикский",
            "Тайский",
            "Тамильский",
            "Татарский",
            "Телугу",
            "Турецкий",
            "Удмуртский",
            "Узбекский",
            "Украинский",
            "Урду",
            "Финский",
            "Французский",
            "Хинди",
            "Хорватский",
            "Чешский",
            "Шведский",
            "Шотландский (гэльский)",
            "Эльфийский (синдарин)",
            "Эмодзи",
            "Эсперанто",
            "Эстонский",
            "Яванский",
            "Японский"});
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Русский";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "Английский";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Немецкий";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "Французский";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cb.SelectedItem = comboBox1.SelectedItem;

            comboBox1.SelectedItem = comboBox2.SelectedItem;

            comboBox2.SelectedItem = cb.SelectedItem;
        }
    }
}
