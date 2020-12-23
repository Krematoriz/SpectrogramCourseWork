using System;
using System.Linq;
using NAudio.Wave;
using System.Drawing;

namespace SpectrogramCourseWork
{
    public class SampleAggregator
    {
        public double[] AmplitudeSamples;

        private readonly int SampleRate = 16000;
        private readonly long SampleCount = 0;

        public SampleAggregator(string filePath)
        {
            WaveFileReader reader = new WaveFileReader(filePath);
            SampleCount = reader.SampleCount;
            SampleRate = reader.WaveFormat.SampleRate;

            AmplitudeSamples = new double[SampleCount];

            float[] buffer;
            int counter = 0;
            while ((buffer = reader.ReadNextSampleFrame())?.Length > 0)
            {
                AmplitudeSamples[counter] = buffer.Average();
                counter++;
            }
        }

        public Bitmap CreateFrequencyBitmap(int width, int height)
        {
            int sectorSize = 1024;
            int sectorCount = (int)(SampleCount / sectorSize);
            Bitmap spectogram = new Bitmap(sectorCount * 10, height);
            int sectorWidth = 10;

            for (int i = 0; i < sectorCount; i++)
            {
                double[] currAmplitudeSamples = new double[sectorSize];
                int currentPointer = i * sectorSize;

                for (int j = 0; j < sectorSize; j++)
                {
                    currAmplitudeSamples[j] = AmplitudeSamples[currentPointer + j];
                }

                double[] powerSamples = FftSharp.Transform.FFTpower(currAmplitudeSamples);
                double[] frequencySamples = FftSharp.Transform.FFTfreq(SampleRate, powerSamples.Length);
                double maxFreq = Math.Min(frequencySamples.Max(), 7000);


                int startIndex = 0;
                int endIndex = 0;

                for (int j = 0; j <  frequencySamples.Length; j++)
                {
                    if (frequencySamples[j] >= 30 && startIndex == 0)
                        startIndex = j;
                    if (frequencySamples[j] >= maxFreq && endIndex == 0)
                        endIndex = j;
                    
                }

                double[] absPowerSamples = new double[powerSamples.Length];

                double maxdB = int.MinValue;
                double mindB = Math.Abs(powerSamples.Min());

                for (int j = 0; j < powerSamples.Length; j++)
                {
                    if (double.IsInfinity(powerSamples[j]))
                    {
                        absPowerSamples[j] = 0;
                        continue;
                    }
                    absPowerSamples[j] = powerSamples[j] + mindB;
                    if (absPowerSamples[j] > maxdB)
                        maxdB = absPowerSamples[j];
                }

                currentPointer = i * sectorWidth;
                for (int x = currentPointer; x < currentPointer + sectorWidth; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        int index = (int)((endIndex - startIndex) * ((float)y / height)) + startIndex;
                        spectogram.SetPixel(x, height - 1 - y, Utils.HeatMapColor(absPowerSamples[index], maxdB));
                    }
                }
            }
            return spectogram;
        }
    }
}
