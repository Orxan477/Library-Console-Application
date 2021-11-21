

namespace LibraryDataBase.Business.Absract
{
    public interface IController<T>
    {
        /// <summary>
        /// Axtarilacaq Name-i qebul edir
        /// </summary>
        /// <param name="name">Axtarilan Name aid tapilan neticeleri ekranda gosteri</param>
        void SelectName(string name);
        /// <summary>
        /// Butun melumatlari gosteri
        /// </summary>
        void GetInfo();
        /// <summary>
        /// Silinecek name -i silir
        /// </summary>
        /// <param name="name">silib silmemesinden asili olmayaraq ekranda musteriye melumat verir</param>
        void Remove(string name);
        /// <summary>
        /// Update edecek name -i update edir
        /// </summary>
        /// <param name="name">Update edib etmemesinden asili olmayaraq ekranda musteriye melumat verir</param>
        void Update(string name);
    }
}
