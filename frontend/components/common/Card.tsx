import React from 'react';
import { cn } from '../../utils/cn';

interface CardProps extends React.HTMLAttributes<HTMLDivElement> {
    children?: React.ReactNode;
}

const Card = React.forwardRef<HTMLDivElement, CardProps>(({ children, className, ...props }, ref) => (
    <div ref={ref} className={cn('bg-white rounded-lg border border-gray-200 shadow-sm hover:shadow-md transition-shadow duration-200 overflow-hidden', className)} {...props}>
        {children}
    </div>
));

const CardHeader = React.forwardRef<HTMLDivElement, CardProps>(({ children, className, ...props }, ref) => (
    <div ref={ref} className={cn('px-6 py-4 border-b border-gray-200', className)} {...props} />
));

const CardTitle = React.forwardRef<HTMLHeadingElement, React.HTMLAttributes<HTMLHeadingElement>>(({ className, ...props }, ref) => (
    <h3 ref={ref} className={cn('text-lg font-bold text-gray-900', className)} {...props} />
));

const CardSubtitle = React.forwardRef<HTMLParagraphElement, React.HTMLAttributes<HTMLParagraphElement>>(({ className, ...props }, ref) => (
    <p ref={ref} className={cn('text-sm text-gray-600 mt-1', className)}{...props} />
));

const CardContent = React.forwardRef<HTMLDivElement, CardProps>(({ className, ...props }, ref) => (
    <div ref={ref} className={cn('px-6 py-4', className)} {...props} />
    )
);

const CardFooter = React.forwardRef<HTMLDivElement, CardProps>(({ className, ...props }, ref) => (
    <div ref={ref} className={cn('px-6 py-4 border-t border-gray-200 bg-gray-50 flex gap-3', className)} {...props} />
    )
);

Card.displayName = 'Card';
CardHeader.displayName = 'CardHeader';
CardTitle.displayName = 'CardTitle';
CardSubtitle.displayName = 'CardSubtitle';
CardContent.displayName = 'CardContent';
CardFooter.displayName = 'CardFooter';

export { Card, CardHeader, CardTitle, CardSubtitle, CardContent, CardFooter };