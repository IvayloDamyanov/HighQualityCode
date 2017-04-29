using System;
using System.Globalization;

namespace Methods
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private string otherInfo;

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        public string OtherInfo
        {
            get
            {
                return this.otherInfo;
            }
            set
            {
                this.otherInfo = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            ArgumentException invalidInfoException = new ArgumentException("Student's info does not contain valid date!");
            if (this.OtherInfo.Length < 10 || other.OtherInfo.Length < 10)
            {
                throw invalidInfoException;
            }

            string firstDate = this.OtherInfo.Substring(this.OtherInfo.Length - 10);
            string secondDate = other.OtherInfo.Substring(other.OtherInfo.Length - 10);
            if (firstDate[2] != '.' || firstDate[5] != '.' || 
                secondDate[2] != '.' || secondDate[5] != '.')
            {
                throw invalidInfoException;
            }
            // Може да се продължи с проверките до безкрай, не мисля че това е идеята

            string dateFormat = "dd.MM.yyyy";
            DateTime thisStudentDate = DateTime.ParseExact(firstDate, dateFormat, CultureInfo.InvariantCulture);
            DateTime otherStudentDate = DateTime.ParseExact(secondDate, dateFormat, CultureInfo.InvariantCulture);
            
            return thisStudentDate < otherStudentDate;
        }
    }
}
