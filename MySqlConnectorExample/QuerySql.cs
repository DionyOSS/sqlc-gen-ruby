// auto-generated by sqlc at 14/04/2024 18:45 - do not edit
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using MySqlConnector;

namespace MySqlConnectorExample;
public class QuerySql(string connectionString)
{
    private static byte[] GetBytes(IDataRecord reader, int ordinal)
    {
        const int bufferSize = 100000;
        ArgumentNullException.ThrowIfNull(reader);
        var buffer = new byte[bufferSize];
        var(bytesRead, offset) = (0, 0);
        while (bytesRead < bufferSize)
        {
            var read = (int)reader.GetBytes(ordinal, bufferSize + bytesRead, buffer, offset, bufferSize - bytesRead);
            if (read == 0)
                break;
            bytesRead += read;
            offset += read;
        }

        if (bytesRead < bufferSize)
            Array.Resize(ref buffer, bytesRead);
        return buffer;
    }

    private const string GetAuthorSql = "SELECT id, name, bio FROM authors WHERE  id  =  @id  LIMIT  1  ";  
    public readonly record struct GetAuthorRow(long Id, string Name, string Bio);
    public readonly record struct GetAuthorArgs(long Id);
    public async Task<GetAuthorRow?> GetAuthor(GetAuthorArgs args)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(GetAuthorSql, connection);
        command.Parameters.AddWithValue("@id", args.Id);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
            return new GetAuthorRow
            {
                Id = reader.GetInt64(0),
                Name = reader.GetString(1),
                Bio = reader.IsDBNull(2) ? string.Empty : reader.GetString(2)
            };
        return null;
    }

    private const string ListAuthorsSql = "SELECT id, name, bio FROM authors ORDER  BY  name  ";  
    public readonly record struct ListAuthorsRow(long Id, string Name, string Bio);
    public async Task<List<ListAuthorsRow>> ListAuthors()
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(ListAuthorsSql, connection);
        await using var reader = await command.ExecuteReaderAsync();
        var rows = new List<ListAuthorsRow>();
        while (await reader.ReadAsync())
        {
            rows.Add(new ListAuthorsRow { Id = reader.GetInt64(0), Name = reader.GetString(1), Bio = reader.IsDBNull(2) ? string.Empty : reader.GetString(2) });
        }

        return rows;
    }

    private const string CreateAuthorSql = "INSERT INTO authors ( name , bio ) VALUES ( @name, @bio ) "; 
    public readonly record struct CreateAuthorArgs(string Name, string Bio);
    public async Task CreateAuthor(CreateAuthorArgs args)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(CreateAuthorSql, connection);
        command.Parameters.AddWithValue("@name", args.Name);
        command.Parameters.AddWithValue("@bio", args.Bio);
        await command.ExecuteScalarAsync();
    }

    private const string CreateAuthorReturnIdSql = "INSERT INTO authors ( name , bio ) VALUES ( @name, @bio ) "; 
    public readonly record struct CreateAuthorReturnIdArgs(string Name, string Bio);
    public async Task<long> CreateAuthorReturnId(CreateAuthorReturnIdArgs args)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(CreateAuthorReturnIdSql, connection);
        command.Parameters.AddWithValue("@name", args.Name);
        command.Parameters.AddWithValue("@bio", args.Bio);
        await command.ExecuteNonQueryAsync();
        return command.LastInsertedId;
    }

    private const string DeleteAuthorSql = "DELETE FROM authors WHERE  id  =  @id  ";  
    public readonly record struct DeleteAuthorArgs(long Id);
    public async Task DeleteAuthor(DeleteAuthorArgs args)
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(DeleteAuthorSql, connection);
        command.Parameters.AddWithValue("@id", args.Id);
        await command.ExecuteScalarAsync();
    }

    private const string TestSql = "SELECT c_bit, c_tinyint, c_bool, c_boolean, c_smallint, c_mediumint, c_int, c_integer, c_bigint, c_serial, c_decimal, c_dec, c_numeric, c_fixed, c_float, c_double, c_double_precision, c_date, c_time, c_datetime, c_timestamp, c_year, c_char, c_nchar, c_national_char, c_varchar, c_binary, c_varbinary, c_tinyblob, c_tinytext, c_blob, c_text, c_mediumblob, c_mediumtext, c_longblob, c_longtext, c_json FROM node_mysql_types LIMIT  1  ";  
    public readonly record struct TestRow(byte[]? C_bit, int? C_tinyint, int? C_bool, int? C_boolean, int? C_smallint, int? C_mediumint, int? C_int, int? C_integer, long? C_bigint, long C_serial, string C_decimal, string C_dec, string C_numeric, string C_fixed, double? C_float, double? C_double, double? C_double_precision, string C_date, string C_time, string C_datetime, string C_timestamp, int? C_year, string C_char, string C_nchar, string C_national_char, string C_varchar, byte[]? C_binary, byte[]? C_varbinary, byte[]? C_tinyblob, string C_tinytext, byte[]? C_blob, string C_text, byte[]? C_mediumblob, string C_mediumtext, byte[]? C_longblob, string C_longtext, object? C_json);
    public async Task<TestRow?> Test()
    {
        await using var connection = new MySqlConnection(connectionString);
        connection.Open();
        await using var command = new MySqlCommand(TestSql, connection);
        await using var reader = await command.ExecuteReaderAsync();
        if (await reader.ReadAsync())
            return new TestRow
            {
                C_bit = reader.IsDBNull(0) ? null : GetBytes(reader, 0),
                C_tinyint = reader.IsDBNull(1) ? null : reader.GetInt32(1),
                C_bool = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                C_boolean = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                C_smallint = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                C_mediumint = reader.IsDBNull(5) ? null : reader.GetInt32(5),
                C_int = reader.IsDBNull(6) ? null : reader.GetInt32(6),
                C_integer = reader.IsDBNull(7) ? null : reader.GetInt32(7),
                C_bigint = reader.IsDBNull(8) ? null : reader.GetInt64(8),
                C_serial = reader.GetInt64(9),
                C_decimal = reader.IsDBNull(10) ? string.Empty : reader.GetString(10),
                C_dec = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                C_numeric = reader.IsDBNull(12) ? string.Empty : reader.GetString(12),
                C_fixed = reader.IsDBNull(13) ? string.Empty : reader.GetString(13),
                C_float = reader.IsDBNull(14) ? null : reader.GetDouble(14),
                C_double = reader.IsDBNull(15) ? null : reader.GetDouble(15),
                C_double_precision = reader.IsDBNull(16) ? null : reader.GetDouble(16),
                C_date = reader.IsDBNull(17) ? string.Empty : reader.GetString(17),
                C_time = reader.IsDBNull(18) ? string.Empty : reader.GetString(18),
                C_datetime = reader.IsDBNull(19) ? string.Empty : reader.GetString(19),
                C_timestamp = reader.IsDBNull(20) ? string.Empty : reader.GetString(20),
                C_year = reader.IsDBNull(21) ? null : reader.GetInt32(21),
                C_char = reader.IsDBNull(22) ? string.Empty : reader.GetString(22),
                C_nchar = reader.IsDBNull(23) ? string.Empty : reader.GetString(23),
                C_national_char = reader.IsDBNull(24) ? string.Empty : reader.GetString(24),
                C_varchar = reader.IsDBNull(25) ? string.Empty : reader.GetString(25),
                C_binary = reader.IsDBNull(26) ? null : GetBytes(reader, 26),
                C_varbinary = reader.IsDBNull(27) ? null : GetBytes(reader, 27),
                C_tinyblob = reader.IsDBNull(28) ? null : GetBytes(reader, 28),
                C_tinytext = reader.IsDBNull(29) ? string.Empty : reader.GetString(29),
                C_blob = reader.IsDBNull(30) ? null : GetBytes(reader, 30),
                C_text = reader.IsDBNull(31) ? string.Empty : reader.GetString(31),
                C_mediumblob = reader.IsDBNull(32) ? null : GetBytes(reader, 32),
                C_mediumtext = reader.IsDBNull(33) ? string.Empty : reader.GetString(33),
                C_longblob = reader.IsDBNull(34) ? null : GetBytes(reader, 34),
                C_longtext = reader.IsDBNull(35) ? string.Empty : reader.GetString(35),
                C_json = reader.IsDBNull(36) ? null : reader.GetString(36)
            };
        return null;
    }
}