import React, { useState, useEffect } from 'react';
import { useRouter } from 'next/router';
import { StatCard } from '../components/dashboard/StatCard';
import { Card, CardContent, CardHeader, CardTitle } from
'@/components/common/Card';
import { Button } from '@/components/common/Button';
import { api } from '@/services/api';
import { Garden } from '@/types';

export default function Dashboard() {
    const router = useRouter();
    const [gardens, setGardens] = useState<Garden[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchGardens = async () => {
            try {
                const response = await api.get('/gardens');
                setGardens(response.data as Garden[]);
            } catch (err) {
                console.error('Error fetching gardens:', err);
            } finally {
                setLoading(false);
            }
        };

        fetchGardens();
    }, []);

    return (
        <div className="min-h-screen bg-gray-50">
            <div className="max-w-7xl mx-auto px-4 py-8">
                <h1 className="text-3xl font-bold text-gray-900 mb-8">Welcome to Garden Manager</h1>

                <div className="grid grid-cols-1 md:grid-cols-2 gap-6 mb-8">
                    <StatCard
                        label="Average Moisture"
                        value="65"
                        unit="%"
                        sensorType="moisture"
                    />
                    <StatCard
                        label="Average Temperature"
                        value="22"
                        unit="°C"
                        sensorType="temperature"
                    />
                </div>

                <div className="mb-8">
                    <div className="flex justify-between items-center mb-4">
                        <h2 className="text-2xl font-bold text-gray-900">Your Gardens</h2>
                            <Button onClick={() => router.push('/gardens/new')}>
                                Create Garden
                            </Button>
                    </div>

                    {loading ? (
                        <p>Loading gardens...</p>
                    ) : (
                        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                            {gardens.map((garden) => (
                                <Card key={garden.id}>
                                    <CardHeader>
                                        <CardTitle>{garden.name}</CardTitle>
                                    </CardHeader>
                                    <CardContent>
                                        <p className="text-sm text-gray-600 mb-4">
                                            {garden.plots.length} plants • {garden.sensors.length} sensors
                                        </p>
                                        <Button
                                            variant="outline"
                                            onClick={() => router.push(`/gardens/${garden.id}`)}
                                        >
                                            View Details
                                        </Button>
                                    </CardContent>
                                </Card>
                            ))}
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}