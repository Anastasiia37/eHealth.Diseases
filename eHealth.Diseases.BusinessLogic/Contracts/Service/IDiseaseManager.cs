using System;
using System.Collections.Generic;
using System.Text;
using eHealth.Diseases.BusinessLogic.DbContext.Entity;

namespace eHealth.Diseases.BusinessLogic.Contracts.Service
{
    public interface IDiseaseManager
    {
        //string GetDiseaseName(int diseaseId);
        IEnumerable<DiseaseCategory> GetDiseaseCategories();

        IEnumerable<Disease> GetDiseasesInCategory(int categoryId);

        Disease GetDisease(int diseaseId);

        int AddDisease(Disease disease);

        int DeleteDisease(int diseaseId);

        int UpdateDisease(int diseaseId, Disease disease);

            /*  /// <summary>
              /// Gets all T entities from the database
              /// </summary>
              /// <returns>The list of T entities</returns>
              IEnumerable<T> Get();

              /// <summary>
              /// Gets the T entity by identifier
              /// </summary>
              /// <param name="id">The identifier of T entity</param>
              /// <returns>T entity with specified id</returns>
              T Get(int id);

              /// <summary>
              /// Adds the T entity to the database
              /// </summary>
              /// <param name="item">The T entity</param>
              /// <returns>The id of the added T entity</returns>
              int Add(T item);

              /// <summary>
              /// Updates the T entity
              /// </summary>
              /// <param name="id">The T entity identifier</param>
              /// <param name="item">The new T entity</param>
              /// <returns>
              /// The id of updated T entity
              /// or null if there isn`t T entity with specified id
              /// </returns>
              int? Update(int id, T item);

              /// <summary>
              /// Removes the T entity from database
              /// <param name="id">The identifier of T entity</param>
              /// <returns>
              /// The id of removed T entity
              /// or null if there isn`t T entity with such id
              /// </returns>
              int? Remove(int id);*/
        }
}