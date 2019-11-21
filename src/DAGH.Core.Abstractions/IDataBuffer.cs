namespace DAGH.Core.Abstractions.Models
{
    public interface IDataBuffer
    {
        byte[] Data { get; }
        int LengthOfEmpty { get; }
        int Length { get; }
    }
}