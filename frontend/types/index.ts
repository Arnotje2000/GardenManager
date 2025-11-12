// User Types
export interface User {
    id: string;
    email: string;
    name: string;
    avatar?: string;
    createdAt: Date;
}

// Garden Types
export interface Garden {
    id: string;
    userId: string;
    name: string;
    description?: string;
    width: number;
    height: number;
    location?: {
        lat: number;
        lng: number;
    };
    plots: GardenPlot[];
    sensors: Sensor[];
    createdAt: Date;
    updatedAt: Date;
}

export interface GardenPlot {
    id: string;
    gardenId: string;
    plantId: string;
    plant?: Plant;
    x: number;
    y: number;
    width: number;
    height: number;
    plantedDate: Date;
    expectedHarvestDate?: Date;
    sensorIds: string[];
    sensors?: Sensor[];
    createdAt: Date;
    updatedAt: Date;
}

// Plant Types
export interface Plant {
    id: string;
    name: string;
    scientificName?: string;
    type: 'vegetable' | 'herb' | 'flower' | 'fruit';
    sowingMonths: number[];
    harvestMonths: number[];
    daysToMaturity: number;
    optimalTemp: {
        min: number;
        max: number;
    };
    optimalMoisture: {
        min: number;
        max: number;
    };
    fertilizationNeeds: {
        nitrogen: number;
        phosphorus: number;
        potassium: number;
    };
    spacing: number;
    sunlight: 'full-sun' | 'partial-shade' | 'shade';
    waterNeeds: 'low' | 'medium' | 'high';
    createdAt: Date;
}

// Sensor Types (ONLY Moisture & Temperature)
export type SensorType = 'moisture' | 'temperature';

export interface Sensor {
    id: string;
    gardenPlotId?: string;
    gardenId: string;
    type: SensorType;
    externalId: string;
    status: 'active' | 'inactive' | 'error';
    lastReadingAt?: Date;
    lastReadingValue?: number;
    createdAt: Date;
    updatedAt: Date;
}

export interface SensorReading {
    id: string;
    sensorId: string;
    value: number;
    unit: string;
    timestamp: Date;
    createdAt: Date;
}

// Fertilization Types
export interface FertilizationPlan {
    id: string;
    gardenPlotId: string;
    plantId: string;
    fertilizerType: string;
    npkRatio: {
        nitrogen: number;
        phosphorus: number;
        potassium: number;
    };
    applicationDate: Date;
    nextApplicationDate: Date;
    notes?: string;
    createdAt: Date;
    updatedAt: Date;
}

// Companion Planting Types
export interface PlantCompanion {
    id: string;
    plantAId: string;
    plantBId: string;
    compatibility: 'good' | 'bad' | 'neutral';
    notes?: string;
}