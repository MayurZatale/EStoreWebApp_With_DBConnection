using HRAPP.Entities;
using MySql.Data.MySqlClient;

namespace HRAPP.Repositories;

public class MySqlDBManager{
    public MySqlDBManager(){}
    public List<Employee> GetAll(){
        List<Employee> employees=new List<Employee>();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=Root123; database=iacsd0923";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="SELECT * from employee";
        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            while(reader.Read()){
                int id= int.Parse(reader["id"].ToString());
                string?  firstName= reader["firstName"].ToString();
                string?  lastName= reader["lastName"].ToString();
                string?  email= reader["email"].ToString();
                string?  address= reader["address"].ToString();
                Employee emp=new Employee();
                emp.Id=id;
                emp.FirstName=firstName;
                emp.LastName=lastName;
                emp.Address=address;
                emp.Email=email;
                employees.Add(emp);
            } 
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            con.Close();
        }
        return employees;
    }
    public  Employee GetById(int id){

        Console.WriteLine(" Getting Employee Details");
        

        Employee  employee=new Employee();
        MySqlConnection con=new MySqlConnection();
        con.ConnectionString=@"server=localhost; port=3306; user=root; password=Root123; database=iacsd0923";
        MySqlCommand cmd=new MySqlCommand();
        cmd.Connection=con;
        cmd.CommandText="SELECT * from employee WHERE id="+ id;
        try{
            con.Open();
            MySqlDataReader reader=cmd.ExecuteReader();
            if(reader.Read()){
                int empId= int.Parse(reader["id"].ToString());
                string?  firstName= reader["firstName"].ToString();
                string?  lastName= reader["lastName"].ToString();
                string?  email= reader["email"].ToString();
                string?  address= reader["address"].ToString();
               
                employee.Id=empId;
                employee.FirstName=firstName;
                employee.LastName=lastName;
                employee.Address=address;
                employee.Email=email;
               
            } 
            reader.Close();
        }
        catch(Exception e){
            
        }
        finally{
            con.Close();
        }
        return employee;
    }




}