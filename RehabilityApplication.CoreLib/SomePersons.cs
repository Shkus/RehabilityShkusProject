using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public class SomePersons
    {
        #region Поля и свойства

        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string Name { get; set; }
        [DisplayName("Возраст")]
        public int Age { get; set; }
        [DisplayName("Выделен?")]
        public bool IsSelected { get; set; }

        #endregion

        #region Конструктор

        /// <summary>
        /// Беспараметрический конструктор.
        /// </summary>
        public SomePersons()
        {

        }

        /// <summary>
        /// Параметрический конструктор
        /// </summary>
        /// <param name="name"></param>
        public SomePersons(string name)
        {
            this.Name = name;
        }

    

        #endregion
    }
}
