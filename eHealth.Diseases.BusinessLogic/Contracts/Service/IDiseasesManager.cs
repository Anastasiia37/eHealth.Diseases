using System.Collections.Generic;

namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    /// <summary>
    /// Interface of services for dealing with subsystem of diseases
    /// </summary>
    /// <typeparam name="T">
    /// T is Disease or DiseaseCategory or PatientDisease
    /// </typeparam>
    public interface IDiseasesManager<T>
    {
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>
        /// The list of all entities
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets the entity of specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>
        /// The entity of specified identifier
        /// </returns>
        T Get(int id);

        /// <summary>
        /// Adds the specified item
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>
        /// Id of added entity
        /// </returns>
        int Add(T item);

        /// <summary>
        /// Deletes the entity with specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <returns>
        /// Id of deleted entity
        /// </returns>
        int Delete(int id);

        /// <summary>
        /// Updates the entity with specified identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        /// <param name="item">The item</param>
        /// <returns>
        /// Id of updated identifier
        /// </returns>
        int Update(int id, T item);
    }
}