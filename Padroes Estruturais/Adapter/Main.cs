using System;
using System.Collections.Generic;

public interface ITemperatureSensor
{
    double ReadTemperature();
}

public class SensorA
{
    public double GetTemperatureInCelsius()
    {
        return 30.0;
    }
}

public class SensorB
{
    public double ObtenerTemperaturaEnCentigrados()
    {
        return 20.0;
    }
}

public class SensorC
{
    public double FetchTempC()
    {
        return 10.0;
    }
}


public class SensorAAdapter : ITemperatureSensor
{
    private SensorA sensorA;

    public SensorAAdapter(SensorA sensor)
    {
        sensorA = sensor;
    }

    public double ReadTemperature()
    {
        return sensorA.GetTemperatureInCelsius();
    }
}

public class SensorBAdapter : ITemperatureSensor
{
    private SensorB sensorB;

    public SensorBAdapter(SensorB sensor)
    {
        sensorB = sensor;
    }

    public double ReadTemperature()
    {
        return sensorB.ObtenerTemperaturaEnCentigrados();
    }
}

public class SensorCAdapter : ITemperatureSensor
{
    private SensorC sensorC;

    public SensorCAdapter(SensorC sensor)
    {
        sensorC = sensor;
    }

    public double ReadTemperature()
    {
        return sensorC.FetchTempC();
    }
}

class Program
{
    static void Main()
    {
        List<ITemperatureSensor> sensores = new List<ITemperatureSensor>
        {
            new SensorAAdapter(new SensorA()),
            new SensorBAdapter(new SensorB()),
            new SensorCAdapter(new SensorC())
        };

        Console.WriteLine("Leitura de temperatura dos sensores:");

        int i = 1;
        foreach (var sensor in sensores)
        {
            Console.WriteLine($"Sensor {(char)(64 + i++)}: {sensor.ReadTemperature()}°C");
        }
    }
}
