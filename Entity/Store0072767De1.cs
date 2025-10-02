namespace DaoXuanHau0072767.Entity
{
    public class Store0072767De1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        
        /// <summary>
        /// Xoá mềm
        /// </summary>
        public bool IsDeleted { get; set; }
        //public DateTime DeletedDate { get; set; }
    }
}
