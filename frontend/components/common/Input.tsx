import React from 'react';
import { cn } from '../../utils/cn';

interface InputProps extends React.InputHTMLAttributes<HTMLInputElement> {
    label?: string;
    error?: string;
    helperText?: string;
    icon?: React.ReactNode;
}

export const Input = React.forwardRef<HTMLInputElement, InputProps>(({ label, error, helperText, icon, className, ...props }, ref) => {
    return (
        <div className="w-full">
            {label && (
                <label className="block text-sm font-medium text-gray-700 mb-2">
                    {label}
                </label>
            )}
            <div className="relative">
            {icon && <div className="absolute left-3 top-1/2 -translate-y-1/2"> {icon}</div>}
        <input
            ref={ref}
            className={cn('w-full px-4 py-2 border rounded-lg transition-all duration-200 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-primary-green',
                icon && 'pl-10',
                error ? 'border-error text-error focus:ring-error' : 'border-gray-300 focus:border-primary-green',
                    'disabled:bg-gray-100 disabled:cursor-not-allowed disabled:opacity-60',
                    className)}
                    {...props}
                />
            </div>
            {error && <p className="mt-1 text-sm text-error">{error}</p>}
            {helperText && !error && <p className="mt-1 text-sm text-gray-500"> {helperText}</p>}
        </div>
    );
});

Input.displayName = 'Input';