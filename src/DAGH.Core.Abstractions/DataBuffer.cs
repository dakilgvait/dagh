namespace DAGH.Core.Abstractions
{
    public class DataBuffer
    {
        public DataBuffer(byte[] buffer, int length)
        {
            this.Data = buffer;
            this.Length = length;
        }

        public DataBuffer(byte[] data)
        : this(data, data.Length) { }

        public DataBuffer(int size)
            : this(new byte[size], 0) { }

        public byte[] Data { get; }

        public int LengthOfEmpty {
            get { return this.Data.Length - this.Length; }
        }

        public int Length { get; set; }
    }
}