using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата Рожденияю
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        //TODO: Make the correct implementation of calculating user age
        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - birthDate.Year;
        //if (birthDate > nowDate.AddYears(-age)) age--;
        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion Properties
        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birthDate">Users birthday date</param>
        /// <param name="weight">Users weight.</param>
        /// <param name="height">Users height.</param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {

            #region Checking conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty.", nameof(name));

            }
            if (gender is null)
            {
                throw new ArgumentNullException("User gender cannot be empty.", nameof(gender));
            }
            if (birthDate <= DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Date of birth is too large or too small.", nameof(birthDate));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("The weight cannot be less than or equal to zero.", nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Growth cannot be less than or equal to zero.", nameof(height));
            }

            #endregion Checking conditions 

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Username cannot be empty.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
