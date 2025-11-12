import React from 'react';
import { Card, CardContent } from '@/components/common/Card';
import { TrendingUp, TrendingDown, Droplet, Thermometer } from 'lucide-react';

interface StatCardProps {
    label: string;
    value: string | number;
    unit: string;
    sensorType: 'moisture' | 'temperature';
    trend?: number;
    optimalMin?: number;
    optimalMax?: number;
}

export const StatCard: React.FC<StatCardProps> = ({
    label,
    value,
    unit,
    sensorType,
    trend,
    optimalMin,
    optimalMax,
}) => {
    const isMoisture = sensorType === 'moisture';
    const colorStyles = isMoisture
        ? 'bg-green-100 text-green-600'
        : 'bg-red-100 text-red-600';
    const icon = isMoisture ? (
        <Droplet className="w-6 h-6" />
    ) : (
        <Thermometer className="w-6 h-6" />
    )

    return (
        <Card>
            <CardContent className="flex items-center gap-4">
                <div className={`p-3 rounded-lg ${colorStyles}`}>
                    {icon}
                </div>
                <div className="flex-1">
                    <p className="text-sm text-gray-600">{label}</p>
                    <p className="text-2xl font-bold text-gray-900">
                        {value}{unit}
                    </p>
                    <div className="flex items-center gap-2 mt-1">
                        {optimalMin !== undefined && optimalMax !== undefined && (
                            <span className="text-xs text-gray-500">
                                Optimal: {optimalMin}-{optimalMax}{unit}
                            </span>
                        )}
                        {trend !== undefined && (
                            <div className="flex items-center gap-1">
                                {trend > 0 ? (
                                    <TrendingUp className="w-4 h-4 text-green-600" />
                                ) : trend < 0 ? (
                                    <TrendingDown className="w-4 h-4 text-red-600" />
                                ) : (
                                    <span className="text-gray-400">→</span>
                                )}
                                <span className={trend > 0 ? 'text-green-600' : trend < 0 ? 'text-red-600' : 'text-gray-500'}>
                                    {Math.abs(trend)}%
                                </span>
                            </div>
                        )}
                    </div>
                </div>
            </CardContent>
        </Card>
    );
};