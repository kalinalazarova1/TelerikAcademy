namespace ComputersBuilder
{
    /// <summary>
    /// Interface for operations performed by the motherboard allowing reading and writing from and to the ram and drawing on the videocard. 
    /// </summary>
    public interface IMotherboard 
    {
        /// <summary>
        /// Loads from ram the previously saved integer value.
        /// </summary>
        /// <returns>The saved integer value.</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves to ram an integer value. If there is already a value in the ram the new one overrides it.
        /// </summary>
        /// <param name="value">Value to be saved.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws the specified string on the video card.
        /// </summary>
        /// <param name="data">String to be drawn from the video card.</param>
        void DrawOnVideoCard(string data);
    }
}
