using ArmyClient.Models.ModelExtremistMaterials;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArmyClient.LogicApp.Interfaces.ExtremistMaterials
{
    interface IExtremistMaterialLogic
    {

        /// <summary>
        /// Получить полный список экстремистских материалов
        /// </summary>
        /// /// <param name="name">Имя с которого начинается поиск материала</param>
        /// <returns>Список экстремистских материалов</returns>
        Task<List<Materials>> GetMaterialsAll(string name = null);


        /// <summary>
        /// Получить найденный список экстремистских материалов
        /// </summary>
        /// <param name="startEntryDate">Дата начала добавления в бд</param>
        /// <param name="endEntryDate">Дата конца добавления в бд</param>
        /// <returns>Список экстремистских материалов</returns>
        Task<List<Materials>> GetFoundedMaterials(DateTime startEntryDate, DateTime endEntreDate);
    }
}
