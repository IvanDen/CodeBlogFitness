using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Users controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// App user.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create new users controller.
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName,
            string genderName, 
            DateTime birdthDay, 
            double weight, 
            double height)
        {
            //TODO check userName

            var gender = new Gender(genderName);

            var user = new User(userName, gender, birdthDay, weight, height);
            User = user;
        }

        /// <summary>
        /// Get user data
        /// </summary>
        /// <returns>App user. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User)
                {
                    User = User;
                }

                // TODO: If user didn't read?
            }
        }

        /// <summary>
        /// Save user data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("User.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }       
        
    }
}
