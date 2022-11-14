

using System;
using System.Data;
using System.Data.SqlClient;


// CRUD Implementation : (CREATE, READ, UPDATE, DELETE)
namespace OptionPricingDAO
{
    public interface IPricingDAO
    {
        int InsertPricing(PricingDTO DTO);
        PricingDTO GetPricing_info(int pricingId);
    }
    public class PricingDAO
    {
        private readonly string _connectionString;

        public PricingDAO() {
            _connectionString = @"Data Source=LAPTOP-IMPOU32Q\SQLEXPRESS;
                                Initial Catalog=OptionPricer.Database;
                                Integrated Security=True";

        }

        public int InsertPricing(PricingDTO varDTO)
        {
            var pricing_id = 0;
            
            using(SqlConnection con = new SqlConnection(_connectionString) )
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("uspInsertPricing") )
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Deskname", varDTO.DeskName) );
                    cmd.Parameters.Add(new SqlParameter("@Nom__", varDTO.FirstName) );
                    cmd.Parameters.Add(new SqlParameter("@Prenom__", varDTO.SecondName) );
                    cmd.Parameters.Add(new SqlParameter("@StockPrice_", varDTO.StockPrice) );
                    cmd.Parameters.Add(new SqlParameter("@RiskFreeRate_", varDTO.RiskFreeRate) );
                    cmd.Parameters.Add(new SqlParameter("@ImpliedVol_", varDTO.ImpliedVolatility) );
                    cmd.Parameters.Add(new SqlParameter("@Maturity__", varDTO.Maturity) );
                    cmd.Parameters.Add(new SqlParameter("@Strike__", varDTO.Strike) );
                    cmd.Parameters.Add(new SqlParameter("@Datetime__", varDTO.DatePricing) );
                    cmd.Parameters.Add(new SqlParameter("@Premium__", varDTO.Premium) );
                    cmd.Parameters.Add(new SqlParameter("@TypeModel", varDTO.ModelType) );
                    cmd.Parameters.Add(new SqlParameter("@OptionType", varDTO.OptionType) );
                    cmd.Parameters.Add(new SqlParameter("@UnderlyingType", varDTO.UnderlyingType) );
                    cmd.Parameters.Add("@Pricing_Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    pricing_id = (int)cmd.Parameters["@Pricing_Id"].Value;

                } 
            }

            Console.WriteLine("New Pricing added Successully...");
            return pricing_id;
        }

        public PricingDTO GetPricing_info(int pricingID)
        {
            PricingDTO pricing_info = new PricingDTO();  
            
            using(SqlConnection con = new SqlConnection(_connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("uspGet_Info_byID"))
                {

                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@PricingId", pricingID));


                    con.Open();
                    using (SqlDataReader myreader = cmd.ExecuteReader())
                    {
                        while (myreader.Read())
                        {
                            if (myreader.HasRows)
                            {
                                pricing_info.DeskName = myreader.GetValue(0).ToString();
                                pricing_info.FirstName = myreader.GetValue(1).ToString();
                                pricing_info.SecondName = myreader.GetValue(2).ToString();
                                pricing_info.StockPrice = Convert.ToSingle(myreader.GetValue(3));
                                pricing_info.RiskFreeRate = Convert.ToSingle(myreader.GetValue(4));
                                pricing_info.ImpliedVolatility = Convert.ToSingle(myreader.GetValue(5));
                                pricing_info.Maturity = Convert.ToDateTime(myreader.GetValue(6));
                                pricing_info.Strike = Convert.ToSingle(myreader.GetValue(7));
                                pricing_info.DatePricing = Convert.ToDateTime(myreader.GetValue(8));
                                pricing_info.Premium = Convert.ToSingle(myreader.GetValue(9));
                                pricing_info.ModelType = myreader.GetValue(10).ToString();
                                pricing_info.OptionType = myreader.GetValue(11).ToString();
                                pricing_info.UnderlyingType = myreader.GetValue(12).ToString();
                                
                                Console.WriteLine("DATA RETRIEVED SUCCESSFULLY......");

                            }

                        }
                        myreader.Close();   

                    }
                    
                }
               
            }

            return pricing_info;
        }

    }
}