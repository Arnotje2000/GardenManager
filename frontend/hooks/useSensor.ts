import { useState, useCallback, useEffect } from 'react';
import { Sensor, SensorReading, SensorType } from '../types';
import { api } from '../services/api';

export const useSensors = (gardenId?: string) => {
    const [sensors, setSensors] = useState<Sensor[]>([]);
    const [readings, setReadings] = useState<Map<string, SensorReading[]>>(new Map());
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState<string | null>(null);

    const fetchSensors = useCallback(async () => {
        if (!gardenId) return;
        setLoading(true);
        try {
            const response = await api.get(`/gardens/${gardenId}/sensors`);
            setSensors(response.data as Sensor[]);
            setError(null);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to fetch sensors');
        } finally {
            setLoading(false);
        }
    }, [gardenId]);

    const fetchSensorReadings = useCallback(async (sensorId: string, timeRange: '24h' | '7d' | '30d' = '24h') => {
        try {
            const response = await api.get(`/sensors/${sensorId}/readings? range=${timeRange}`);
            setReadings((prev) => new Map(prev).set(sensorId, response.data as SensorReading[]));
            return response.data;
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to fetch sensor readings');
        throw err;
        }
    }, []);

    const addSensor = useCallback(async (sensor: Omit<Sensor, 'id' | 'createdAt' | 'updatedAt'>) => {
        if (!gardenId) return;
        try {
            const response = await api.post(`/gardens/${gardenId}/sensors`, sensor);
            setSensors((prev) => [...prev, response.data as Sensor]);
            return response.data;
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to add sensor');
            throw err;
        }
    }, [gardenId]);

    const removeSensor = useCallback(async (sensorId: string) => {
        try {
            await api.delete(`/sensors/${sensorId}`);
            setSensors((prev) => prev.filter((s) => s.id !== sensorId));
            setReadings((prev) => {
                const newReadings = new Map(prev);
                newReadings.delete(sensorId);
                return newReadings;
            });
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Failed to remove sensor');
            throw err;
        }
    }, []);

    useEffect(() => {
        fetchSensors();
    }, [fetchSensors]);

    return {
        sensors,
        readings,
        loading,
        error,
        fetchSensors,
        fetchSensorReadings,
        addSensor,
        removeSensor,
    };
};