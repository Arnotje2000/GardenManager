import type { AppProps } from 'next/app';
import { useRouter } from 'next/router';
import '@/styles/globals.css';

export default function App({ Component, pageProps }: AppProps) {
    const router = useRouter();
    const isAuthPage = router.pathname.startsWith('/auth');
   
   return (
        <div>
            <Component {...pageProps} />
        </div>
    );
}