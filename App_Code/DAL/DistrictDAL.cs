using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.IO;
using Microsoft.ApplicationBlocks.Data;


/// <summary>
/// Summary description for DistrictDAL
/// </summary>
public class DistrictDAL
{
    DataSet ds = new DataSet();
    int status;
    public DistrictDAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public DataTable DALDistrictShowAll()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spDistrictSelect");
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        return ds.Tables[0];
    }


    public int DALInsertDistrict(DistrictBLL dt)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {

                SqlParameter[] par = new SqlParameter[3];
                par[0] = new SqlParameter("@distName", dt.distName);
                par[1] = new SqlParameter("@stateId", dt.stateId);
                par[2] = new SqlParameter("@Status", 100);
                par[2].Direction = ParameterDirection.Output;

                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDistrictInsert", par);
                status = (int)par[2].Value;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }


    public bool DALIsExistDistrictName(DistrictBLL dt)
    {

        bool flag = false;
        string row = "";
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {

            try
            {

                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@distName", dt.distName);
                par[1] = new SqlParameter("@Status", 11);
                par[1].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spDistrictIsExistByName", par));



            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        if (row != "")
        {
            flag = true;

        }
        return flag;
    }



    public bool DALIsExistDistrict(DistrictBLL dt)
    {

        string row = "";
        bool flag = false;


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@distId", dt.distId);
                par[1] = new SqlParameter("@distName", dt.distName);
                par[2] = new SqlParameter("@stateId", dt.stateId);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                row = Convert.ToString(SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "spDistrictIsExist", par));
            }


            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        if (row != "")
        {
            flag = true;
        }
        return flag;
    }


    public int DALDistrictUpdate(DistrictBLL dt)
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[4];
                par[0] = new SqlParameter("@distId", dt.distId);
                par[1] = new SqlParameter("@distName", dt.distName);
                par[2] = new SqlParameter("@stateId", dt.stateId);
                par[3] = new SqlParameter("@Status", 11);
                par[3].Direction = ParameterDirection.Output;
                SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "spDistrictUpdate", par);
                status = (int)par[3].Value;
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
        return status;
    }



    public DataTable DALGetSelectedDistrict(DistrictBLL dt)
    {

        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@distId", dt.distId);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spDistrictSelectById", par);

            }


            catch (SqlException ex)
            {
                throw ex;

            }
            finally
            {
                con.Close();
            }

        }
        return ds.Tables[0];
    }


    public string DALDistrictSelectName(int id)
    {


        string name = "";



        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@distId", id);
                par[1] = new SqlParameter("@status", 11);
                par[1].Direction = ParameterDirection.Output;
                using (SqlDataReader dr = SqlHelper.ExecuteReader(con, CommandType.StoredProcedure, "spDistrictSelectById", par))
                {
                    if (dr.HasRows)
                    {
                        dr.Read();
                        name = Convert.ToString(dr["distName"]);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }
        return name;

    }


    public DataTable DALDistrictSelectBySId(DistrictBLL dt, int sid)
    {

        List<DistrictBLL> dtList = new List<DistrictBLL>();


        using (SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]))
        {
            try
            {
                SqlParameter[] par = new SqlParameter[2];
                par[0] = new SqlParameter("@stateId", sid);

                ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "spDistrictSelectBySId", par);

            }

            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();

            }
        }
        return ds.Tables[0];
    }

    public DataTable DALDistrictHCShowAll(int stateId)
    {
        DataTable dtDistrictShowAll = new DataTable();

        DataColumn distId = new DataColumn("distId", typeof(Int32));
        DataColumn distName = new DataColumn("distName", typeof(string));
        DataColumn sId = new DataColumn("stateId", typeof(Int32));
        dtDistrictShowAll.Columns.Add(distId);
        dtDistrictShowAll.Columns.Add(distName);
        dtDistrictShowAll.Columns.Add(sId);
        try
        {
            switch (stateId)
            {
                //Add District Of Andra Pradesh
                case 1:
                    dtDistrictShowAll.Rows.Add(1, "Adilabad", 1);
                    dtDistrictShowAll.Rows.Add(2, "Anantapura", 1);
                    dtDistrictShowAll.Rows.Add(3, "Chittoor", 1);
                    dtDistrictShowAll.Rows.Add(4, "Cuddapah", 1);
                    dtDistrictShowAll.Rows.Add(5, "EastGodavari", 1);
                    dtDistrictShowAll.Rows.Add(6, "Guntur", 1);
                    dtDistrictShowAll.Rows.Add(7, "Hyderabad", 1);
                    dtDistrictShowAll.Rows.Add(8, "Karimnagar", 1);
                    dtDistrictShowAll.Rows.Add(9, "Khammam", 1);
                    dtDistrictShowAll.Rows.Add(10, "Krishna", 1);
                    dtDistrictShowAll.Rows.Add(11, "Kurnool", 1);
                    dtDistrictShowAll.Rows.Add(12, "Mahbubnagar", 1);
                    dtDistrictShowAll.Rows.Add(13, "Medak", 1);
                    dtDistrictShowAll.Rows.Add(14, "Nalgonda", 1);
                    dtDistrictShowAll.Rows.Add(15, "Nellore", 1);
                    dtDistrictShowAll.Rows.Add(16, "Nizamabad", 1);
                    dtDistrictShowAll.Rows.Add(17, "Prakasam", 1);
                    dtDistrictShowAll.Rows.Add(18, "Rangareddi", 1);
                    dtDistrictShowAll.Rows.Add(19, "Srikakulam", 1);
                    dtDistrictShowAll.Rows.Add(20, "Visakhapatnam", 1);
                    dtDistrictShowAll.Rows.Add(21, "Vizianagaram ", 1);
                    dtDistrictShowAll.Rows.Add(22, "Warangal", 1);
                    dtDistrictShowAll.Rows.Add(23, "West Godavari", 1);
                    break;



                //Add District Of Arunachal Pradesh
                case 2:
                    dtDistrictShowAll.Rows.Add(24, "Anjaw", 2);
                    dtDistrictShowAll.Rows.Add(25, "Changlang", 2);
                    dtDistrictShowAll.Rows.Add(26, "Dibang Valley", 2);
                    dtDistrictShowAll.Rows.Add(27, "East Kameng", 2);
                    dtDistrictShowAll.Rows.Add(28, "East Siang", 2);
                    dtDistrictShowAll.Rows.Add(29, "Kurung Kumey", 2);
                    dtDistrictShowAll.Rows.Add(30, "Lohit", 2);
                    dtDistrictShowAll.Rows.Add(31, "LowerSubansiri", 2);
                    dtDistrictShowAll.Rows.Add(32, "Papum Pare", 2);
                    dtDistrictShowAll.Rows.Add(33, "Tawang", 2);
                    dtDistrictShowAll.Rows.Add(34, "Tirap", 2);
                    dtDistrictShowAll.Rows.Add(35, "Upper Siang", 2);
                    dtDistrictShowAll.Rows.Add(36, "Upper Subansiri", 2);
                    dtDistrictShowAll.Rows.Add(37, "WestKameng", 2);
                    dtDistrictShowAll.Rows.Add(38, "West Siang", 2);
                    dtDistrictShowAll.Rows.Add(39, "Lower DihangValley", 2);
                    break;




                //Add District Of Assam
                case 3:
                    dtDistrictShowAll.Rows.Add(40, "Barpeta", 3);
                    dtDistrictShowAll.Rows.Add(41, "Bongaigaon", 3);
                    dtDistrictShowAll.Rows.Add(42, "Cachar", 3);
                    dtDistrictShowAll.Rows.Add(43, "Darrang", 3);
                    dtDistrictShowAll.Rows.Add(44, "Dhemaji", 3);
                    dtDistrictShowAll.Rows.Add(45, "Dhubri", 3);
                    dtDistrictShowAll.Rows.Add(46, "Dibrugarh", 3);
                    dtDistrictShowAll.Rows.Add(47, "Goalpara", 3);
                    dtDistrictShowAll.Rows.Add(48, "Golaghat", 3);
                    dtDistrictShowAll.Rows.Add(49, "Hailakand", 3);
                    dtDistrictShowAll.Rows.Add(50, "Jorhat", 3);
                    dtDistrictShowAll.Rows.Add(51, "Kamrup", 3);
                    dtDistrictShowAll.Rows.Add(52, "Karbi Anglong", 3);
                    dtDistrictShowAll.Rows.Add(53, "Karimgan", 3);
                    dtDistrictShowAll.Rows.Add(54, "Kokrajhar", 3);
                    dtDistrictShowAll.Rows.Add(55, "Lakhimpur", 3);
                    dtDistrictShowAll.Rows.Add(56, "Marigaon", 3);
                    dtDistrictShowAll.Rows.Add(57, "Nagaon", 3);
                    dtDistrictShowAll.Rows.Add(58, "Nalbar", 3);
                    dtDistrictShowAll.Rows.Add(59, "North Cachar", 3);
                    dtDistrictShowAll.Rows.Add(60, "Sivasagar", 3);
                    dtDistrictShowAll.Rows.Add(61, "Sonitpur", 3);
                    dtDistrictShowAll.Rows.Add(62, "Tinsukia", 3);
                    dtDistrictShowAll.Rows.Add(63, "Kamrup", 3);
                    dtDistrictShowAll.Rows.Add(64, "Udalguri", 3);
                    dtDistrictShowAll.Rows.Add(65, "Baksa", 3);
                    dtDistrictShowAll.Rows.Add(66, "Chirang", 3);
                    break;



                //Add District Of Bihar
                case 4:
                    dtDistrictShowAll.Rows.Add(67, "Araria", 4);
                    dtDistrictShowAll.Rows.Add(68, "Aurangabad", 4);
                    dtDistrictShowAll.Rows.Add(69, "Banka", 4);
                    dtDistrictShowAll.Rows.Add(70, "Begusarai", 4);
                    dtDistrictShowAll.Rows.Add(71, "Bhagalpur", 4);
                    dtDistrictShowAll.Rows.Add(72, "Bhojpuri", 4);
                    dtDistrictShowAll.Rows.Add(73, "Buxar", 4);
                    dtDistrictShowAll.Rows.Add(74, "Darbhanga", 4);
                    dtDistrictShowAll.Rows.Add(75, "D Gaya", 4);
                    dtDistrictShowAll.Rows.Add(76, "Gopalganj", 4);
                    dtDistrictShowAll.Rows.Add(77, "Jamui", 4);
                    dtDistrictShowAll.Rows.Add(78, "Jehanabad", 4);
                    dtDistrictShowAll.Rows.Add(79, "Kaimur", 4);
                    dtDistrictShowAll.Rows.Add(80, "Katihar", 4);
                    dtDistrictShowAll.Rows.Add(81, "Khagaria", 4);
                    dtDistrictShowAll.Rows.Add(82, "Kishangani", 4);
                    dtDistrictShowAll.Rows.Add(83, "Lakhisara", 4);
                    dtDistrictShowAll.Rows.Add(84, "Madhepura", 4);
                    dtDistrictShowAll.Rows.Add(85, "Madhubani", 4);
                    dtDistrictShowAll.Rows.Add(86, "Munger", 4);
                    dtDistrictShowAll.Rows.Add(87, "Muzaffarpur", 4);
                    dtDistrictShowAll.Rows.Add(88, "Nalanda", 4);
                    dtDistrictShowAll.Rows.Add(89, "Nawada", 4);
                    dtDistrictShowAll.Rows.Add(90, "PashchimChamparan", 4);
                    dtDistrictShowAll.Rows.Add(91, "Patna", 4);
                    dtDistrictShowAll.Rows.Add(92, "Purba Champaran", 4);
                    dtDistrictShowAll.Rows.Add(93, "Purnia", 4);
                    dtDistrictShowAll.Rows.Add(94, "Rohtas", 4);
                    dtDistrictShowAll.Rows.Add(95, "Saharsa", 4);
                    dtDistrictShowAll.Rows.Add(96, "Samastipur", 4);
                    dtDistrictShowAll.Rows.Add(97, "Saran", 4);
                    dtDistrictShowAll.Rows.Add(98, "Sheikhpura Sheohar", 4);
                    dtDistrictShowAll.Rows.Add(99, "Sheohar", 4);
                    dtDistrictShowAll.Rows.Add(100, "Sitamarh", 4);
                    dtDistrictShowAll.Rows.Add(101, "Siwan", 4);
                    dtDistrictShowAll.Rows.Add(102, "Supaul", 4);
                    dtDistrictShowAll.Rows.Add(103, "Vaishali", 4);
                    break;



                //Add District Of Chhattisgarh
                case 5:
                    dtDistrictShowAll.Rows.Add(104, "Bastar", 5);
                    dtDistrictShowAll.Rows.Add(105, "Bilaspur", 5);
                    dtDistrictShowAll.Rows.Add(106, "Dantewada", 5);
                    dtDistrictShowAll.Rows.Add(107, "Dhamtari", 5);
                    dtDistrictShowAll.Rows.Add(108, "Durg", 5);
                    dtDistrictShowAll.Rows.Add(109, "Janjgir-Champa", 5);
                    dtDistrictShowAll.Rows.Add(110, "Jashpur", 5);
                    dtDistrictShowAll.Rows.Add(111, "Kanker", 5);
                    dtDistrictShowAll.Rows.Add(112, "Kawardha", 5);
                    dtDistrictShowAll.Rows.Add(113, "Korba", 5);
                    dtDistrictShowAll.Rows.Add(114, "Koriya", 5);
                    dtDistrictShowAll.Rows.Add(115, "Mahasamund", 5);
                    dtDistrictShowAll.Rows.Add(116, "Raigarh", 5);
                    dtDistrictShowAll.Rows.Add(117, "Raipur", 5);
                    dtDistrictShowAll.Rows.Add(118, "Rajnandgaon", 5);
                    dtDistrictShowAll.Rows.Add(119, "Surguja", 5);
                    break;



                //Add District Of Goa
                case 6:
                    dtDistrictShowAll.Rows.Add(120, "North Goa", 6);
                    dtDistrictShowAll.Rows.Add(121, "South Goa", 6);
                    break;


                //Add District Of Gujarat
                case 7:
                    dtDistrictShowAll.Rows.Add(122, "Ahmedabad ", 7);
                    dtDistrictShowAll.Rows.Add(123, "Amreli ", 7);
                    dtDistrictShowAll.Rows.Add(124, "Anand", 7);
                    dtDistrictShowAll.Rows.Add(125, "Banas Kantha ", 7);
                    dtDistrictShowAll.Rows.Add(126, "Bharuch ", 7);
                    dtDistrictShowAll.Rows.Add(127, "Bhavnagar ", 7);
                    dtDistrictShowAll.Rows.Add(128, "Dohad ", 7);
                    dtDistrictShowAll.Rows.Add(129, "Gandhinagar ", 7);
                    dtDistrictShowAll.Rows.Add(130, "Jamnagar ", 7);
                    dtDistrictShowAll.Rows.Add(131, "Junagadh ", 7);
                    dtDistrictShowAll.Rows.Add(132, "Kutch ", 7);
                    dtDistrictShowAll.Rows.Add(133, "Kheda ", 7);
                    dtDistrictShowAll.Rows.Add(134, "Mahesana ", 7);
                    dtDistrictShowAll.Rows.Add(135, "Narmada ", 7);
                    dtDistrictShowAll.Rows.Add(136, "Navsari ", 7);
                    dtDistrictShowAll.Rows.Add(137, "Panch Mahals", 7);
                    dtDistrictShowAll.Rows.Add(138, "Patan ", 7);
                    dtDistrictShowAll.Rows.Add(139, "Porbandar ", 7);
                    dtDistrictShowAll.Rows.Add(140, "Rajkot ", 7);
                    dtDistrictShowAll.Rows.Add(141, "Sabar Kantha ", 7);
                    dtDistrictShowAll.Rows.Add(142, "Surat ", 7);
                    dtDistrictShowAll.Rows.Add(143, "Surendranagar ", 7);
                    dtDistrictShowAll.Rows.Add(144, "Dangs ", 7);
                    dtDistrictShowAll.Rows.Add(145, "Vadodara ", 7);
                    dtDistrictShowAll.Rows.Add(146, "Valsad ", 7);
                    dtDistrictShowAll.Rows.Add(147, "Tapi", 7);
                    break;



                //Add District Of Haryana
                case 8:
                    dtDistrictShowAll.Rows.Add(148, "Ambala ", 8);
                    dtDistrictShowAll.Rows.Add(149, "Bhiwani ", 8);
                    dtDistrictShowAll.Rows.Add(150, "Faridabad ", 8);
                    dtDistrictShowAll.Rows.Add(151, "Fatehabad ", 8);
                    dtDistrictShowAll.Rows.Add(152, "Gurgaon ", 8);
                    dtDistrictShowAll.Rows.Add(153, "Hisar ", 8);
                    dtDistrictShowAll.Rows.Add(154, "Jhajjar ", 8);
                    dtDistrictShowAll.Rows.Add(155, "Jind ", 8);
                    dtDistrictShowAll.Rows.Add(156, "Kaithal ", 8);
                    dtDistrictShowAll.Rows.Add(157, "Karnal ", 8);
                    dtDistrictShowAll.Rows.Add(158, "Kurukshetra ", 8);
                    dtDistrictShowAll.Rows.Add(159, "Mahendragarh ", 8);
                    dtDistrictShowAll.Rows.Add(160, "Mewat ", 8);
                    dtDistrictShowAll.Rows.Add(161, "Panchkula ", 8);
                    dtDistrictShowAll.Rows.Add(162, "Panipat ", 8);
                    dtDistrictShowAll.Rows.Add(163, "Rewari", 8);
                    dtDistrictShowAll.Rows.Add(164, "Rohtak ", 8);
                    dtDistrictShowAll.Rows.Add(165, "Sirsa ", 8);
                    dtDistrictShowAll.Rows.Add(166, "Sonipat ", 8);
                    dtDistrictShowAll.Rows.Add(167, "Yamunanagar ", 8);
                    break;



                //Add District Of Himachal
                case 9:
                    dtDistrictShowAll.Rows.Add(168, "Bilaspur ", 9);
                    dtDistrictShowAll.Rows.Add(169, "Chamba ", 9);
                    dtDistrictShowAll.Rows.Add(170, "Hamirpur ", 9);
                    dtDistrictShowAll.Rows.Add(171, "Kangra ", 9);
                    dtDistrictShowAll.Rows.Add(172, "Kinnaur ", 9);
                    dtDistrictShowAll.Rows.Add(173, "Kullu ", 9);
                    dtDistrictShowAll.Rows.Add(174, "Lahaul & Spiti ", 9);
                    dtDistrictShowAll.Rows.Add(175, "Mandi ", 9);
                    dtDistrictShowAll.Rows.Add(176, "Shimla ", 9);
                    dtDistrictShowAll.Rows.Add(177, "Sirmaur ", 9);
                    dtDistrictShowAll.Rows.Add(178, "Solan ", 9);
                    dtDistrictShowAll.Rows.Add(179, "Una ", 9);
                    break;

                //Add District Of Jammu and Kashmir
                case 10:
                    dtDistrictShowAll.Rows.Add(180, "Anantnag ", 10);
                    dtDistrictShowAll.Rows.Add(181, "Budgam ", 10);
                    dtDistrictShowAll.Rows.Add(182, "Baramulla ", 10);
                    dtDistrictShowAll.Rows.Add(183, "Doda ", 10);
                    dtDistrictShowAll.Rows.Add(184, "Jammu ", 10);
                    dtDistrictShowAll.Rows.Add(185, "Kargil ", 10);
                    dtDistrictShowAll.Rows.Add(186, "Kathua ", 10);
                    dtDistrictShowAll.Rows.Add(187, "Kupwara ", 10);
                    dtDistrictShowAll.Rows.Add(188, "Leh ", 9);
                    dtDistrictShowAll.Rows.Add(189, "Pulwama ", 10);
                    dtDistrictShowAll.Rows.Add(190, "Poonch ", 10);
                    dtDistrictShowAll.Rows.Add(191, "Rajauri ", 10);
                    dtDistrictShowAll.Rows.Add(192, "Srinagar ", 10);
                    dtDistrictShowAll.Rows.Add(193, "Udhampur ", 10);
                    dtDistrictShowAll.Rows.Add(194, "Samba ", 10);
                    dtDistrictShowAll.Rows.Add(195, "Reasi ", 10);
                    dtDistrictShowAll.Rows.Add(196, "Ramban ", 10);
                    dtDistrictShowAll.Rows.Add(197, "Kishtwar ", 10);
                    dtDistrictShowAll.Rows.Add(198, " Kulgam ", 10);
                    dtDistrictShowAll.Rows.Add(199, "Shopian ", 10);
                    dtDistrictShowAll.Rows.Add(200, "Ganderbal ", 10);
                    dtDistrictShowAll.Rows.Add(201, "Bandipora ", 10);
                    break;


                //Add District Of Jharkhand
                case 11:
                    dtDistrictShowAll.Rows.Add(202, "Bokaro ", 11);
                    dtDistrictShowAll.Rows.Add(203, "Chatra ", 11);
                    dtDistrictShowAll.Rows.Add(204, "Deoghar ", 11);
                    dtDistrictShowAll.Rows.Add(205, "Dhanbad ", 11);
                    dtDistrictShowAll.Rows.Add(206, "Dumka ", 11);
                    dtDistrictShowAll.Rows.Add(207, "Garhwa ", 11);
                    dtDistrictShowAll.Rows.Add(208, "Giridih ", 11);
                    dtDistrictShowAll.Rows.Add(209, "Godda ", 11);
                    dtDistrictShowAll.Rows.Add(210, "Gumla ", 11);
                    dtDistrictShowAll.Rows.Add(211, "Hazaribag ", 11);
                    dtDistrictShowAll.Rows.Add(212, "Jamtara ", 11);
                    dtDistrictShowAll.Rows.Add(213, "Koderma ", 11);
                    dtDistrictShowAll.Rows.Add(214, "Lohardaga ", 11);
                    dtDistrictShowAll.Rows.Add(215, "Pakur ", 11);
                    dtDistrictShowAll.Rows.Add(216, "Palamu ", 11);
                    dtDistrictShowAll.Rows.Add(217, "West Singhbhum ", 11);
                    dtDistrictShowAll.Rows.Add(218, "East Singhbhum", 11);
                    dtDistrictShowAll.Rows.Add(219, "Ranchi ", 11);
                    dtDistrictShowAll.Rows.Add(220, "Sahibganj ", 11);
                    dtDistrictShowAll.Rows.Add(221, "Seraikela ", 11);
                    dtDistrictShowAll.Rows.Add(222, "Latehar ", 11);
                    dtDistrictShowAll.Rows.Add(223, "Simdega ", 11);
                    break;

                //Add District Of Karnataka
                case 12:
                    dtDistrictShowAll.Rows.Add(224, "Bagalkot ", 12);
                    dtDistrictShowAll.Rows.Add(225, "Bangalore ", 12);
                    dtDistrictShowAll.Rows.Add(226, "Bangalore Rural ", 12);
                    dtDistrictShowAll.Rows.Add(227, "Belgaum ", 12);
                    dtDistrictShowAll.Rows.Add(228, "Bellary ", 12);
                    dtDistrictShowAll.Rows.Add(229, "Bidar ", 12);
                    dtDistrictShowAll.Rows.Add(230, "Bijapur ", 12);
                    dtDistrictShowAll.Rows.Add(231, "Chamrajnagar ", 12);
                    dtDistrictShowAll.Rows.Add(232, "Chickmagalur ", 12);
                    dtDistrictShowAll.Rows.Add(233, "Chitradurga ", 12);
                    dtDistrictShowAll.Rows.Add(234, "Dakshin Kannada ", 12);
                    dtDistrictShowAll.Rows.Add(235, "Davangere", 12);
                    dtDistrictShowAll.Rows.Add(236, "Dharwad ", 12);
                    dtDistrictShowAll.Rows.Add(237, "Gadag ", 12);
                    dtDistrictShowAll.Rows.Add(238, "Gulbarga ", 12);
                    dtDistrictShowAll.Rows.Add(239, "Hassan", 12);
                    dtDistrictShowAll.Rows.Add(240, "Haveri ", 12);
                    dtDistrictShowAll.Rows.Add(241, "Kodagu ", 12);
                    dtDistrictShowAll.Rows.Add(242, "Kolar ", 12);
                    dtDistrictShowAll.Rows.Add(243, "Koppal ", 12);
                    dtDistrictShowAll.Rows.Add(244, "Mandya ", 12);
                    dtDistrictShowAll.Rows.Add(245, "Mysore ", 12);
                    dtDistrictShowAll.Rows.Add(246, "Raichur ", 12);
                    dtDistrictShowAll.Rows.Add(247, "Shimoga ", 12);
                    dtDistrictShowAll.Rows.Add(248, "Tumkur ", 12);
                    dtDistrictShowAll.Rows.Add(249, "Udupi ", 12);
                    dtDistrictShowAll.Rows.Add(250, "UttarKannada ", 12);
                    break;

                //Add District Of Kerala
                case 13:
                    dtDistrictShowAll.Rows.Add(251, "Alappuzha ", 13);
                    dtDistrictShowAll.Rows.Add(252, "Ernakulam ", 13);
                    dtDistrictShowAll.Rows.Add(253, "Idukki ", 13);
                    dtDistrictShowAll.Rows.Add(254, "Kannur ", 13);
                    dtDistrictShowAll.Rows.Add(255, "Kasargod ", 13);
                    dtDistrictShowAll.Rows.Add(256, "Kollam ", 13);
                    dtDistrictShowAll.Rows.Add(257, "Kottayam ", 13);
                    dtDistrictShowAll.Rows.Add(258, "Kozhikode ", 13);
                    dtDistrictShowAll.Rows.Add(259, "Malappuram ", 13);
                    dtDistrictShowAll.Rows.Add(260, "Palakkad ", 13);
                    dtDistrictShowAll.Rows.Add(261, "Pathanamthitta ", 13);
                    dtDistrictShowAll.Rows.Add(262, "Thiruvananthapuram", 13);
                    dtDistrictShowAll.Rows.Add(263, "Thrissur ", 13);
                    dtDistrictShowAll.Rows.Add(264, "Wayanad ", 13);
                    break;


                //Add District Of Madya Pradesh
                case 14:
                    dtDistrictShowAll.Rows.Add(265, "Balaghat", 14);
                    dtDistrictShowAll.Rows.Add(266, "Barwani", 14);
                    dtDistrictShowAll.Rows.Add(267, "Betul", 14);
                    dtDistrictShowAll.Rows.Add(268, "Bhind", 14);
                    dtDistrictShowAll.Rows.Add(269, "Bhopal", 14);
                    dtDistrictShowAll.Rows.Add(270, "Chhatarpur", 14);
                    dtDistrictShowAll.Rows.Add(271, "Chhindwara", 14);
                    dtDistrictShowAll.Rows.Add(272, "Damoh", 14);
                    dtDistrictShowAll.Rows.Add(273, "Datia", 14);
                    dtDistrictShowAll.Rows.Add(274, "Dewas", 14);
                    dtDistrictShowAll.Rows.Add(275, "Dhar", 14);
                    dtDistrictShowAll.Rows.Add(276, "Dindori", 14);
                    dtDistrictShowAll.Rows.Add(277, "Khandwa", 14);
                    dtDistrictShowAll.Rows.Add(278, "Guna", 14);
                    dtDistrictShowAll.Rows.Add(279, "Gwalior", 14);
                    dtDistrictShowAll.Rows.Add(280, "Harda", 14);
                    dtDistrictShowAll.Rows.Add(281, "Hoshangabad", 14);
                    dtDistrictShowAll.Rows.Add(282, "Indore", 14);
                    dtDistrictShowAll.Rows.Add(283, "Jabalpur", 14);
                    dtDistrictShowAll.Rows.Add(284, "Jhabua", 14);
                    dtDistrictShowAll.Rows.Add(285, "Katni", 14);
                    dtDistrictShowAll.Rows.Add(286, "Mandla", 14);
                    dtDistrictShowAll.Rows.Add(287, "Mandsaur", 14);
                    dtDistrictShowAll.Rows.Add(288, "Morena", 14);
                    dtDistrictShowAll.Rows.Add(289, "Narsinghpu", 14);
                    dtDistrictShowAll.Rows.Add(290, "Neemuch", 14);
                    dtDistrictShowAll.Rows.Add(291, "Panna", 14);
                    dtDistrictShowAll.Rows.Add(292, "Raisen", 14);
                    dtDistrictShowAll.Rows.Add(293, "Rajgarh", 14);
                    dtDistrictShowAll.Rows.Add(294, "Ratlam", 14);
                    dtDistrictShowAll.Rows.Add(295, "Rewa", 14);
                    dtDistrictShowAll.Rows.Add(296, "Sagar", 14);
                    dtDistrictShowAll.Rows.Add(297, "Satna", 14);
                    dtDistrictShowAll.Rows.Add(298, "Sehore", 14);
                    dtDistrictShowAll.Rows.Add(299, "Seoni", 14);
                    dtDistrictShowAll.Rows.Add(300, "Shahdol", 14);
                    dtDistrictShowAll.Rows.Add(301, "Shajapur", 14);
                    dtDistrictShowAll.Rows.Add(302, "Sheopur", 14);
                    dtDistrictShowAll.Rows.Add(303, "Shivpuri ", 14);
                    dtDistrictShowAll.Rows.Add(304, "Sidhi ", 14);
                    dtDistrictShowAll.Rows.Add(305, "Tikamgarh", 14);
                    dtDistrictShowAll.Rows.Add(306, "Ujjain ", 14);
                    dtDistrictShowAll.Rows.Add(307, "Umaria ", 14);
                    dtDistrictShowAll.Rows.Add(308, "Vidisha ", 14);
                    dtDistrictShowAll.Rows.Add(309, "Khargone", 14);
                    dtDistrictShowAll.Rows.Add(310, "Anuppur", 14);
                    dtDistrictShowAll.Rows.Add(311, "Burhanpur", 14);
                    dtDistrictShowAll.Rows.Add(312, "Alirajpur", 14);
                    dtDistrictShowAll.Rows.Add(313, "Singrauli", 14);
                    dtDistrictShowAll.Rows.Add(314, "Ashoknagar ", 14);
                    break;


                //Add District Of Maharashtra
                case 15:
                    dtDistrictShowAll.Rows.Add(315, "Ahmednagar ", 15);
                    dtDistrictShowAll.Rows.Add(316, "Akola ", 15);
                    dtDistrictShowAll.Rows.Add(317, "Amravati ", 15);
                    dtDistrictShowAll.Rows.Add(318, "Aurangabad ", 15);
                    dtDistrictShowAll.Rows.Add(319, "Bhandara ", 15);
                    dtDistrictShowAll.Rows.Add(320, "Beed ", 15);
                    dtDistrictShowAll.Rows.Add(321, "Buldhana ", 15);
                    dtDistrictShowAll.Rows.Add(322, "Chandrapur ", 15);
                    dtDistrictShowAll.Rows.Add(323, "Dhule ", 15);
                    dtDistrictShowAll.Rows.Add(324, "Gadchiroli ", 15);
                    dtDistrictShowAll.Rows.Add(325, "Gondia ", 15);
                    dtDistrictShowAll.Rows.Add(326, "Hingoli ", 15);
                    dtDistrictShowAll.Rows.Add(327, "Jalgaon ", 15);
                    dtDistrictShowAll.Rows.Add(328, "Jalna ", 15);
                    dtDistrictShowAll.Rows.Add(329, "Kolhapur ", 15);
                    dtDistrictShowAll.Rows.Add(330, "Latur", 15);
                    dtDistrictShowAll.Rows.Add(331, "Mumbai ", 15);
                    dtDistrictShowAll.Rows.Add(332, "Mumbai Suburban ", 15);
                    dtDistrictShowAll.Rows.Add(333, "Nagpur ", 15);
                    dtDistrictShowAll.Rows.Add(334, "Nanded ", 15);
                    dtDistrictShowAll.Rows.Add(335, "Nandurbar ", 15);
                    dtDistrictShowAll.Rows.Add(336, "Nashik ", 15);
                    dtDistrictShowAll.Rows.Add(337, "Osmanabad ", 15);
                    dtDistrictShowAll.Rows.Add(338, "Parbhani ", 15);
                    dtDistrictShowAll.Rows.Add(339, "Pune ", 15);
                    dtDistrictShowAll.Rows.Add(340, "Raigad ", 15);
                    dtDistrictShowAll.Rows.Add(341, "Ratnagiri ", 15);
                    dtDistrictShowAll.Rows.Add(342, "Sangli ", 15);
                    dtDistrictShowAll.Rows.Add(343, "Satara ", 15);
                    dtDistrictShowAll.Rows.Add(344, "Sindhudurg ", 15);
                    dtDistrictShowAll.Rows.Add(345, "Solapur ", 15);
                    dtDistrictShowAll.Rows.Add(346, "Thane ", 15);
                    dtDistrictShowAll.Rows.Add(347, "Wardha ", 15);
                    dtDistrictShowAll.Rows.Add(348, "Washim ", 15);
                    dtDistrictShowAll.Rows.Add(349, "Yavatmal ", 15);
                    break;


                //Add District Of Manipur
                case 16:
                    dtDistrictShowAll.Rows.Add(350, "Bishnupur ", 16);
                    dtDistrictShowAll.Rows.Add(351, "Chandel ", 16);
                    dtDistrictShowAll.Rows.Add(352, "Churachandpur ", 16);
                    dtDistrictShowAll.Rows.Add(353, "Imphal East ", 16);
                    dtDistrictShowAll.Rows.Add(354, "Imphal West ", 16);
                    dtDistrictShowAll.Rows.Add(355, "Senapati ", 16);
                    dtDistrictShowAll.Rows.Add(356, "Tamenglong ", 16);
                    dtDistrictShowAll.Rows.Add(357, "Thoubal ", 16);
                    dtDistrictShowAll.Rows.Add(358, "Ukhrul ", 16);
                    break;


                //Add District Of Meghalaya
                case 17:
                    dtDistrictShowAll.Rows.Add(359, "EastGaroHills", 17);
                    dtDistrictShowAll.Rows.Add(360, "EastKhasiHills", 17);
                    dtDistrictShowAll.Rows.Add(361, "Jaintia Hills ", 17);
                    dtDistrictShowAll.Rows.Add(362, "Ri Bhoi", 17);
                    dtDistrictShowAll.Rows.Add(363, "South Garo Hills", 17);
                    dtDistrictShowAll.Rows.Add(364, "West Garo Hills", 17);
                    dtDistrictShowAll.Rows.Add(365, "West Khasi Hills", 17);
                    break;

                //Add District Of Mizoram
                case 18:
                    dtDistrictShowAll.Rows.Add(366, "Aizawl ", 18);
                    dtDistrictShowAll.Rows.Add(367, "Champhai ", 18);
                    dtDistrictShowAll.Rows.Add(368, "Kolasib ", 18);
                    dtDistrictShowAll.Rows.Add(369, "Lawngtlai ", 18);
                    dtDistrictShowAll.Rows.Add(370, "Lunglei ", 18);
                    dtDistrictShowAll.Rows.Add(371, "Mamit", 18);
                    dtDistrictShowAll.Rows.Add(372, "Saiha", 18);
                    dtDistrictShowAll.Rows.Add(373, "Serchhip", 18);
                    break;



                //Add District Of Nagaland
                case 19:
                    dtDistrictShowAll.Rows.Add(374, "Dimapur ", 19);
                    dtDistrictShowAll.Rows.Add(375, "Kohima ", 19);
                    dtDistrictShowAll.Rows.Add(376, "Mokokchung ", 19);
                    dtDistrictShowAll.Rows.Add(377, "Mon ", 19);
                    dtDistrictShowAll.Rows.Add(378, "Phek ", 19);
                    dtDistrictShowAll.Rows.Add(379, "Tuensang ", 19);
                    dtDistrictShowAll.Rows.Add(380, "Wokha ", 19);
                    dtDistrictShowAll.Rows.Add(381, "Zunheboto ", 19);
                    break;

                //Add District Of Orissa
                case 20:
                    dtDistrictShowAll.Rows.Add(382, "Anugul ", 20);
                    dtDistrictShowAll.Rows.Add(383, "Balangir ", 20);
                    dtDistrictShowAll.Rows.Add(384, "Baleswar ", 20);
                    dtDistrictShowAll.Rows.Add(385, "Bargarh ", 20);
                    dtDistrictShowAll.Rows.Add(386, "Boudh ", 20);
                    dtDistrictShowAll.Rows.Add(387, "Bhadrak ", 20);
                    dtDistrictShowAll.Rows.Add(388, "Cuttack ", 20);
                    dtDistrictShowAll.Rows.Add(389, "Deogarh ", 20);
                    dtDistrictShowAll.Rows.Add(390, "Dhenkanal ", 20);
                    dtDistrictShowAll.Rows.Add(391, "Gajapati ", 20);
                    dtDistrictShowAll.Rows.Add(392, "Ganjam ", 20);
                    dtDistrictShowAll.Rows.Add(393, "Jagatsinghapur ", 20);
                    dtDistrictShowAll.Rows.Add(394, "Jajpur ", 20);
                    dtDistrictShowAll.Rows.Add(395, "Jharsuguda ", 20);
                    dtDistrictShowAll.Rows.Add(396, "Kalahandi ", 20);
                    dtDistrictShowAll.Rows.Add(397, "Kandhamal", 20);
                    dtDistrictShowAll.Rows.Add(398, "Kendrapara ", 20);
                    dtDistrictShowAll.Rows.Add(399, "Kendujhar ", 20);
                    dtDistrictShowAll.Rows.Add(400, "Khordha ", 20);
                    dtDistrictShowAll.Rows.Add(401, "Koraput ", 20);
                    dtDistrictShowAll.Rows.Add(402, "Malkangiri ", 20);
                    dtDistrictShowAll.Rows.Add(403, "Mayurbhanj ", 20);
                    dtDistrictShowAll.Rows.Add(404, "Nabarangapur ", 20);
                    dtDistrictShowAll.Rows.Add(405, "Nayagarh ", 20);
                    dtDistrictShowAll.Rows.Add(406, "Nuapada ", 20);
                    dtDistrictShowAll.Rows.Add(407, "Puri ", 20);
                    dtDistrictShowAll.Rows.Add(408, "Rayagada ", 20);
                    dtDistrictShowAll.Rows.Add(409, "Sambalpur ", 20);
                    dtDistrictShowAll.Rows.Add(410, "Subarnapur ", 20);
                    dtDistrictShowAll.Rows.Add(411, "Sundergarh ", 20);
                    break;

                //Add District Of Punjab
                case 21:
                    dtDistrictShowAll.Rows.Add(312, "Amritsar ", 21);
                    dtDistrictShowAll.Rows.Add(313, "Bathinda ", 21);
                    dtDistrictShowAll.Rows.Add(314, "Faridkot ", 21);
                    dtDistrictShowAll.Rows.Add(315, "Fatehgarh Sahib ", 21);
                    dtDistrictShowAll.Rows.Add(316, "Ferozepur ", 21);
                    dtDistrictShowAll.Rows.Add(317, "Gurdaspur ", 21);
                    dtDistrictShowAll.Rows.Add(318, "Hoshiarpur ", 21);
                    dtDistrictShowAll.Rows.Add(319, "Jalandhar ", 21);
                    dtDistrictShowAll.Rows.Add(320, "Kapurthala ", 21);
                    dtDistrictShowAll.Rows.Add(321, "Ludhiana ", 21);
                    dtDistrictShowAll.Rows.Add(322, "Mansa ", 21);
                    dtDistrictShowAll.Rows.Add(323, "Moga ", 21);
                    dtDistrictShowAll.Rows.Add(324, " Muktsar ", 21);
                    dtDistrictShowAll.Rows.Add(325, "Nawanshahr ", 21);
                    dtDistrictShowAll.Rows.Add(326, "Patiala ", 21);
                    dtDistrictShowAll.Rows.Add(327, "Rupnagar ", 21);
                    dtDistrictShowAll.Rows.Add(328, "Sangrur", 21);
                    dtDistrictShowAll.Rows.Add(329, "Barnala ", 21);
                    dtDistrictShowAll.Rows.Add(330, "Mohali ", 21);
                    dtDistrictShowAll.Rows.Add(331, "Tarn Taran ", 21);
                    break;

                //Add District Of Rajasthan
                case 22:
                    dtDistrictShowAll.Rows.Add(332, "Ajmer ", 22);
                    dtDistrictShowAll.Rows.Add(333, "Alwar ", 22);
                    dtDistrictShowAll.Rows.Add(334, "Banswara ", 22);
                    dtDistrictShowAll.Rows.Add(335, "Baran ", 22);
                    dtDistrictShowAll.Rows.Add(336, "Barmer ", 22);
                    dtDistrictShowAll.Rows.Add(337, "Bharatpur ", 22);
                    dtDistrictShowAll.Rows.Add(338, "Bhilwara ", 22);
                    dtDistrictShowAll.Rows.Add(339, "Bikaner ", 22);
                    dtDistrictShowAll.Rows.Add(340, "Bundi ", 22);
                    dtDistrictShowAll.Rows.Add(341, "Chittorgarh ", 22);
                    dtDistrictShowAll.Rows.Add(342, "Churu ", 22);
                    dtDistrictShowAll.Rows.Add(343, "Dausa ", 22);
                    dtDistrictShowAll.Rows.Add(344, "Dholpur ", 22);
                    dtDistrictShowAll.Rows.Add(345, "Dungarpur ", 22);
                    dtDistrictShowAll.Rows.Add(346, "Sri Ganganagar ", 22);
                    dtDistrictShowAll.Rows.Add(347, "Hanumangarh", 22);
                    dtDistrictShowAll.Rows.Add(348, "Jaipur ", 22);
                    dtDistrictShowAll.Rows.Add(349, "Jaisalmer ", 22);
                    dtDistrictShowAll.Rows.Add(350, "Jalor ", 22);
                    dtDistrictShowAll.Rows.Add(351, "Jhalawar ", 22);
                    dtDistrictShowAll.Rows.Add(352, "Jhunjhunu ", 22);
                    dtDistrictShowAll.Rows.Add(353, "Jodhpur ", 22);
                    dtDistrictShowAll.Rows.Add(354, "Karauli ", 22);
                    dtDistrictShowAll.Rows.Add(355, "Kota ", 22);
                    dtDistrictShowAll.Rows.Add(356, "Nagaur ", 22);
                    dtDistrictShowAll.Rows.Add(357, "Pali ", 22);
                    dtDistrictShowAll.Rows.Add(358, "Rajsamand ", 22);
                    dtDistrictShowAll.Rows.Add(359, "Sawai Madhopur ", 22);
                    dtDistrictShowAll.Rows.Add(360, "Sikar ", 22);
                    dtDistrictShowAll.Rows.Add(361, "Sirohi ", 22);
                    dtDistrictShowAll.Rows.Add(362, "Tonk ", 22);
                    dtDistrictShowAll.Rows.Add(363, "Udaipur ", 22);
                    dtDistrictShowAll.Rows.Add(364, "Pratapgarh ", 22);
                    break;



                //Add District Of Sikkim
                case 23:
                    dtDistrictShowAll.Rows.Add(365, "EastSikkim ", 23);
                    dtDistrictShowAll.Rows.Add(366, "NorthSikkim ", 23);
                    dtDistrictShowAll.Rows.Add(367, "SouthSikkim ", 23);
                    dtDistrictShowAll.Rows.Add(368, "West Sikkim ", 23);
                    break;

                //Add District Of Tamil Nadu
                case 24:
                    dtDistrictShowAll.Rows.Add(369, "Ariyalur ", 24);
                    dtDistrictShowAll.Rows.Add(370, "Chennai ", 24);
                    dtDistrictShowAll.Rows.Add(371, "Coimbatore ", 24);
                    dtDistrictShowAll.Rows.Add(372, "Cuddalore ", 24);
                    dtDistrictShowAll.Rows.Add(373, "Dharmapuri ", 24);
                    dtDistrictShowAll.Rows.Add(374, "Dindigul ", 24);
                    dtDistrictShowAll.Rows.Add(375, "Erode ", 24);
                    dtDistrictShowAll.Rows.Add(376, "Kanchipuram ", 24);
                    dtDistrictShowAll.Rows.Add(377, "Kanyakumari ", 24);
                    dtDistrictShowAll.Rows.Add(378, "Karur ", 24);
                    dtDistrictShowAll.Rows.Add(379, "Madurai ", 24);
                    dtDistrictShowAll.Rows.Add(380, "Nagapattinam ", 24);
                    dtDistrictShowAll.Rows.Add(381, "Namakkal ", 24);
                    dtDistrictShowAll.Rows.Add(382, "Perambalur ", 24);
                    dtDistrictShowAll.Rows.Add(383, "Pudukkottai ", 24);
                    dtDistrictShowAll.Rows.Add(384, "Ramanathapuram", 24);
                    dtDistrictShowAll.Rows.Add(385, "Salem ", 24);
                    dtDistrictShowAll.Rows.Add(386, "Sivaganga ", 24);
                    dtDistrictShowAll.Rows.Add(387, "Thanjavur ", 24);
                    dtDistrictShowAll.Rows.Add(388, "Nilgiris ", 24);
                    dtDistrictShowAll.Rows.Add(389, "Theni", 24);
                    dtDistrictShowAll.Rows.Add(390, "Tiruvallur ", 24);
                    dtDistrictShowAll.Rows.Add(391, "Tiruvarur ", 24);
                    dtDistrictShowAll.Rows.Add(392, "Thoothukudi ", 24);
                    dtDistrictShowAll.Rows.Add(393, "Tiruchirappalli", 24);
                    dtDistrictShowAll.Rows.Add(394, "Tirunelveli ", 24);
                    dtDistrictShowAll.Rows.Add(395, "Tiruvannamalai ", 24);
                    dtDistrictShowAll.Rows.Add(396, "Vellore ", 24);
                    dtDistrictShowAll.Rows.Add(397, "Viluppuram ", 24);
                    dtDistrictShowAll.Rows.Add(398, "Virudhunagar ", 24);
                    dtDistrictShowAll.Rows.Add(399, "Krishnagiri ", 24);

                    break;

                //Add District Of Tripura
                case 25:
                    dtDistrictShowAll.Rows.Add(400, "Dhalai", 25);
                    dtDistrictShowAll.Rows.Add(401, "North Tripura", 25);
                    dtDistrictShowAll.Rows.Add(402, "South Tripura", 25);
                    dtDistrictShowAll.Rows.Add(403, "West Tripura", 25);

                    break;

                //Add District Of Uttaranchal
                case 26:
                    dtDistrictShowAll.Rows.Add(404, "Almora ", 26);
                    dtDistrictShowAll.Rows.Add(405, "Bageshwar ", 26);
                    dtDistrictShowAll.Rows.Add(406, "Chamoli ", 26);
                    dtDistrictShowAll.Rows.Add(407, "Champawat", 26);
                    dtDistrictShowAll.Rows.Add(408, "Dehradun", 26);
                    dtDistrictShowAll.Rows.Add(409, "Payri Garhwal", 26);
                    dtDistrictShowAll.Rows.Add(410, "Haridwar", 26);
                    dtDistrictShowAll.Rows.Add(411, "Nainital", 26);
                    dtDistrictShowAll.Rows.Add(412, "Pithoragarh", 26);
                    dtDistrictShowAll.Rows.Add(413, "Rudraprayag", 26);
                    dtDistrictShowAll.Rows.Add(414, "Tehri Garwahal", 26);
                    dtDistrictShowAll.Rows.Add(415, "Udham Singh Nagar", 26);
                    dtDistrictShowAll.Rows.Add(416, "Uttarkashi", 26);
                    break;

                //Add District Of Uttar Pradesh
                case 27:
                    dtDistrictShowAll.Rows.Add(417, "Agra", 27);
                    dtDistrictShowAll.Rows.Add(418, "Aligarh", 27);
                    dtDistrictShowAll.Rows.Add(419, "Allahabad", 27);
                    dtDistrictShowAll.Rows.Add(420, "Ambedkar Nagar", 27);
                    dtDistrictShowAll.Rows.Add(421, "Auraiya", 27);
                    dtDistrictShowAll.Rows.Add(422, "Azamgarh", 27);
                    dtDistrictShowAll.Rows.Add(423, "Bagpat", 27);
                    dtDistrictShowAll.Rows.Add(424, "Bahraich", 27);
                    dtDistrictShowAll.Rows.Add(425, "Ballia", 27);
                    dtDistrictShowAll.Rows.Add(426, "Balrampur", 27);
                    dtDistrictShowAll.Rows.Add(427, "Banda", 27);
                    dtDistrictShowAll.Rows.Add(428, "Barabanki", 27);
                    dtDistrictShowAll.Rows.Add(429, "Bareilly", 27);
                    dtDistrictShowAll.Rows.Add(430, "Basti", 27);
                    dtDistrictShowAll.Rows.Add(431, "Bijnor", 27);
                    dtDistrictShowAll.Rows.Add(432, "Budaun", 27);
                    dtDistrictShowAll.Rows.Add(433, "Bulandshahr", 27);
                    dtDistrictShowAll.Rows.Add(434, "Chandauli", 27);
                    dtDistrictShowAll.Rows.Add(435, "Chitrakoot", 27);
                    dtDistrictShowAll.Rows.Add(436, "Deoria", 27);
                    dtDistrictShowAll.Rows.Add(437, "Etah", 27);
                    dtDistrictShowAll.Rows.Add(438, "Etawah", 27);
                    dtDistrictShowAll.Rows.Add(439, "Faizabad", 27);
                    dtDistrictShowAll.Rows.Add(440, "Farrukhabad", 27);
                    dtDistrictShowAll.Rows.Add(441, "Fatehpur", 27);
                    dtDistrictShowAll.Rows.Add(442, "Firozabad", 27);
                    dtDistrictShowAll.Rows.Add(443, "Gautam BuddhaNagar", 27);
                    dtDistrictShowAll.Rows.Add(444, "Ghaziabad", 27);
                    dtDistrictShowAll.Rows.Add(445, "Ghazipur", 27);
                    dtDistrictShowAll.Rows.Add(446, "Gonda", 27);
                    dtDistrictShowAll.Rows.Add(447, "Gorakhpur", 27);
                    dtDistrictShowAll.Rows.Add(448, "Hamirpur", 27);
                    dtDistrictShowAll.Rows.Add(449, "Hardoi", 27);
                    dtDistrictShowAll.Rows.Add(450, "Hathras", 27);
                    dtDistrictShowAll.Rows.Add(451, "Jalaun", 27);
                    dtDistrictShowAll.Rows.Add(452, "Jaunpu", 27);
                    dtDistrictShowAll.Rows.Add(453, "Jhansi", 27);
                    dtDistrictShowAll.Rows.Add(454, "Jyotiba Phule Nagar", 27);
                    dtDistrictShowAll.Rows.Add(455, "Kannauj", 27);
                    dtDistrictShowAll.Rows.Add(456, "Kanpur Dehat", 27);
                    dtDistrictShowAll.Rows.Add(457, "Kanpur Nagar", 27);
                    dtDistrictShowAll.Rows.Add(458, "Kaushambi", 27);
                    dtDistrictShowAll.Rows.Add(459, "D Kheri", 43);
                    dtDistrictShowAll.Rows.Add(460, "Kushinagar", 27);
                    dtDistrictShowAll.Rows.Add(461, "Lalitpur", 27);
                    dtDistrictShowAll.Rows.Add(462, "Lucknow", 27);
                    dtDistrictShowAll.Rows.Add(463, "Mahoba", 27);
                    dtDistrictShowAll.Rows.Add(464, "Maharajganj", 27);
                    dtDistrictShowAll.Rows.Add(465, "Mainpuri", 27);
                    dtDistrictShowAll.Rows.Add(466, "Mathura", 27);
                    dtDistrictShowAll.Rows.Add(467, "Mau", 27);
                    dtDistrictShowAll.Rows.Add(468, "Meerut", 27);
                    dtDistrictShowAll.Rows.Add(469, "Mirzapur", 27);
                    dtDistrictShowAll.Rows.Add(470, "Moradabad", 27);
                    dtDistrictShowAll.Rows.Add(471, "Muzaffarnagar", 27);
                    dtDistrictShowAll.Rows.Add(472, "Pilibhit", 27);
                    dtDistrictShowAll.Rows.Add(473, "Pratapgarh", 27);
                    dtDistrictShowAll.Rows.Add(474, "RaeBareli", 27);
                    dtDistrictShowAll.Rows.Add(475, "Rampur", 27);
                    dtDistrictShowAll.Rows.Add(476, "Saharanpur", 27);
                    dtDistrictShowAll.Rows.Add(477, "Sant Kabir Nagar", 27);
                    dtDistrictShowAll.Rows.Add(478, "Sant RavidasNagar", 27);
                    dtDistrictShowAll.Rows.Add(479, "Shahjahanpur", 27);
                    dtDistrictShowAll.Rows.Add(480, "Shravasti", 27);
                    dtDistrictShowAll.Rows.Add(481, "Siddharthnagar", 27);
                    dtDistrictShowAll.Rows.Add(482, "Sitapur", 27);
                    dtDistrictShowAll.Rows.Add(483, "Sonbhadra", 27);
                    dtDistrictShowAll.Rows.Add(484, "Sultanpur", 27);
                    dtDistrictShowAll.Rows.Add(485, " Unnao", 27);
                    dtDistrictShowAll.Rows.Add(486, "Varanasi", 27);
                    dtDistrictShowAll.Rows.Add(487, "ManyavarKanshiramNagar", 27);
                    break;

                //Add District Of West Bengal
                case 28:
                    dtDistrictShowAll.Rows.Add(488, "Bankura ", 28);
                    dtDistrictShowAll.Rows.Add(489, "Bardhaman ", 28);
                    dtDistrictShowAll.Rows.Add(490, "Birbhum ", 28);
                    dtDistrictShowAll.Rows.Add(491, "SouthDinajpur(Dakshin)", 28);
                    dtDistrictShowAll.Rows.Add(492, "Darjeeling ", 28);
                    dtDistrictShowAll.Rows.Add(493, "Howrah ", 28);
                    dtDistrictShowAll.Rows.Add(494, "Hooghly ", 28);
                    dtDistrictShowAll.Rows.Add(495, "Jalpaiguri ", 28);
                    dtDistrictShowAll.Rows.Add(496, "Cooch Behar ", 28);
                    dtDistrictShowAll.Rows.Add(497, "Kolkata ", 28);
                    dtDistrictShowAll.Rows.Add(498, " Malda ", 28);
                    dtDistrictShowAll.Rows.Add(499, "East Medinipur ", 28);
                    dtDistrictShowAll.Rows.Add(500, " Murshidabad ", 28);
                    dtDistrictShowAll.Rows.Add(501, "Nadia ", 28);
                    dtDistrictShowAll.Rows.Add(502, "North 24 Parganas ", 28);
                    dtDistrictShowAll.Rows.Add(503, "Purulia ", 28);
                    dtDistrictShowAll.Rows.Add(504, "South 24 Parganas", 28);
                    dtDistrictShowAll.Rows.Add(505, "North Dinajpur(Uttar)", 28);
                    dtDistrictShowAll.Rows.Add(506, "West Medinipur (Paschim) ", 28);

                    break;

                //Add District Of Andaman and Nicobar
                case 29:
                    dtDistrictShowAll.Rows.Add(507, "D Andaman ", 29);
                    dtDistrictShowAll.Rows.Add(508, "Nicobar ", 29);
                    break;


                //Add District Of Chandigarh
                case 30:
                    dtDistrictShowAll.Rows.Add(1, "D Chandigarh");
                    break;
                //Add District Of Dadar and Nagar Haveli
                case 31:
                    dtDistrictShowAll.Rows.Add(1, "D Dadar and Nagar Haveli");
                    break;
                //Add District Of Daman and Diu
                case 32:
                    dtDistrictShowAll.Rows.Add(1, "D Daman and Diu");
                    break;
                //Add District Of Delhi
                case 33:
                    dtDistrictShowAll.Rows.Add(1, "D Delhi");
                    break;
                //Add District Of Lakshadeep
                case 34:
                    dtDistrictShowAll.Rows.Add(1, "D Lakshadeep");
                    break;
                //Add District Of Pondicherry
                case 35:
                    dtDistrictShowAll.Rows.Add(1, "D Pondicherry");
                    break;


                default:
                    dtDistrictShowAll.Rows.Add(1, "Select City");
                    break;


            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return dtDistrictShowAll;
    }
}
