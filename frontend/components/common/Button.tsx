import React from 'react';
import { cn } from '../../utils/cn';

interface ButtonProps extends React.ButtonHTMLAttributes<HTMLButtonElement> {
    variant?: 'primary' | 'secondary' | 'outline' | 'icon';
    size?: 'sm' | 'md' | 'lg';
    isLoading?: boolean;
    icon?: React.ReactNode;
    children?: React.ReactNode;
} 

export const Button = React.forwardRef<HTMLButtonElement, ButtonProps>(
    (
        {
            variant = 'primary',
            size = 'md',
            isLoading = false,
            icon,
            className,
            disabled,
            children,
            ...props
        },
        ref
    ) => {
        const baseStyles = 'font-medium rounded-lg transition-all duration-200 flex items-center justify-center gap-2 focus:outline-none focus:ring-2 focus:ringoffset-2 focus:ring-primary-green disabled:opacity-50 disabled:cursor-notallowed';
        const variants = {
            primary: 'bg-primary-green text-white hover:bg-dark-green active:scale-95 focus:ring-primary-green',
            secondary: 'bg-light-green text-primary-green hover:bg-primary-green hover:text-white active:scale-95 focus:ring-primary-green',
            outline: 'border-2 border-primary-green text-primary-green hover:bg-light-green active:scale-95 focus:ring-primary-green',
            icon: 'bg-transparent text-primary-green hover:bg-light-green roundedfull p-2 focus:ring-primary-green',
        };
        const sizes = {
        sm: 'h-8 px-3 text-sm',
        md: 'h-10 px-4 text-base',
        lg: 'h-12 px-6 text-lg',
        };
        return (
            <button
                ref={ref}
                className={cn(baseStyles, variants[variant], sizes[size], className)}
                disabled={disabled || isLoading}
                {...props}
            >
                {isLoading ? (
                    <>
                        <div className="animate-spin w-4 h-4 border-2 border-current border-t-transparent rounded-full" />
                        {children}
                    </>
                ) : (
                    <>
                        {icon}
                        {children}
                    </>
                )}
            </button>
        );
    }
);