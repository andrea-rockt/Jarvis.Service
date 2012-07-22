namespace Jarvis.Service.Domain.DomainModel
{
    public interface IBusinessEquatable
    {
        /// <summary>
        /// Returns wether other is equivalent in content without checking for id equaliy
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        bool BusinessEquals(object other );
    }
}