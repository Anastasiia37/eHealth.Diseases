using System;
using System.ComponentModel.DataAnnotations;

namespace eHealth.Diseases.BusinessLogic.DbContext.Entity
{
    /// <summary>
    /// Represents a model of Patient as stored in Database
    /// </summary>
    public class PatientInfo
    {
        /// <summary>
        /// Gets or sets a Unique number to identify the book and store in the Database
        /// </summary>
        [Key]
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        /// <value>
        /// The first name
        /// </value>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        /// <value>
        /// The last name
        /// </value>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the country
        /// </summary>
        /// <value>
        /// The country
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        /// <value>
        /// The city
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the address
        /// </summary>
        /// <value>
        /// The address
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the birth date
        /// </summary>
        /// <value>
        /// The birth date
        /// </value>
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the phone
        /// </summary>
        /// <value>
        /// The phone
        /// </value>
        [MaxLength(12)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the gender
        /// </summary>
        /// <value>
        /// The gender
        /// </value>
        public byte Gender { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        /// <value>
        /// The email
        /// </value>
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the image identifier
        /// </summary>
        /// <value>
        /// The image identifier
        /// </value>
        public int ImageId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>
        /// </value>
        public bool IsDeleted { get; set; }
    }
}