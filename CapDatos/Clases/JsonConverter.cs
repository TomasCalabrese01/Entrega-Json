
using System.Collections.Generic;
using System.Text.Json;
using System.Data;
namespace CapaDeDatos
{
    public class JsonConverter : IJsonConverter
    {
        public string RowToJson(DataRow row)
        {
            var rowDict =new Dictionary<string, object>();  
            foreach (DataColumn column in row.Table.Columns) 
            {
                rowDict.Add(column.ColumnName, row[column]);
            }
             var jsonRow = JsonSerializer.Serialize(rowDict);
             
            return jsonRow;
        }
        public string TableToJson(DataTable dt)//convierte la lista en Json
        {
            //crea una lista que almacena los diccionarios
            List<Dictionary<string,object>> ListDict = new List<Dictionary<string,object>>();   
        
        foreach (DataRow row in dt.Rows) //recorre cada fila 
            {
                //crea un diccionario para la fila actual
                Dictionary<string, object> rowDict = new Dictionary<string, object>();
                //itera sobre las columnas de la data table
                foreach (DataColumn column in dt.Columns) 
                {
                    //agrega un par clave-valor al diccionario
                    rowDict.Add(column.ColumnName, row[column]);
                }
            ListDict.Add(rowDict);  
         
            }
        string jsonList = JsonSerializer.Serialize(ListDict);
        return jsonList;
        }
            
            
    
            
            
            
            
            
            
            
            
     }
    
}
