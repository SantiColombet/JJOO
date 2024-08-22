using System.Data.SqlClient;
using Dapper;

public class bd
{
    private static string _connectionString = @"Server=127.0.0.1; DataBase=JJOO; Trusted_Connection=True;";
    public static void AgregarDeportista(Deportista _deportista)
    {
        string sql = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) Values (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
        using(SqlConnection db = new SqlConnection(_connectionString) ){            
            db.Execute(sql, new{pApellido = _deportista.Apellido, pNombre = _deportista.Nombre, pFechaNacimiento = _deportista.FechaNacimiento, pFoto = _deportista.Foto, pIdPais = _deportista.IdPais, pIdDeporte = _deportista.IdDeporte});
        }
    }

    public static void EliminarDeportista(int idDeportista)
    {
        string sql = "DELETE FROM Deportistas WHERE IdDeportista = @pIdDeportista";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            db.Execute(sql, new { pIdDeportista = idDeportista });
        }
    } 

    public static Deporte? VerInfoDeporte (int idDeporte)
    {
        string sql = "SELECT * FROM Deportes WHERE IdDeporte = @pidDeporte";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.QueryFirstOrDefault<Deporte>(sql, new { pidDeporte = idDeporte });
        }
    }
    public static Pais? VerInfoPais (int idPais)
    {
        
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            string sql = "SELECT * FROM Paises WHERE IdPais = @pidPais";
            return db.QueryFirstOrDefault<Pais>(sql, new {pidPais = idPais});
        }
    } 
    public static Pais? VerInfoDeportista (int idDeportista)
    {
        string sql = "SELECT * FROM Deportistas WHERE IdDeportista = @pidDeportista";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.QueryFirstOrDefault<Pais>(sql, new {pidDeportista = idDeportista});
        }
    }   
    public static List<Pais> ListarPaises ()
    {
        string sql = "SELECT * FROM Paises";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.Query<Pais>(sql).ToList();
        }
    }  
    public static List<Deportista> ListarDeportistas (int idDeporte)
    {
        string sql = "SELECT * FROM Deportistas WHERE IdDeporte = @pidDeporte";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.Query<Deportista>(sql, new {pidDeporte = idDeporte}).ToList();
        }
    }  
    public static List<Deportista> ListarDeportistasPais (int idPais)
    {
        string sql = "SELECT * FROM Deportistas WHERE IdPais = @pidPais";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.Query<Deportista>(sql, new {pidPais = idPais}).ToList();
        }
    }  
        public static List<Deporte> ListarDeportes ()
    {
        string sql = "SELECT * FROM Deportes";
        using (SqlConnection db = new SqlConnection(_connectionString))
        {   
            return db.Query<Deporte>(sql).ToList();
        }
    }  
}
