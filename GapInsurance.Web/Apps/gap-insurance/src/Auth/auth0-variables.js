export const AUTH_CONFIG = {
  domain: 'jugoval.auth0.com',
  clientId: '9HCt2WIX9KtdE21Xyw1LBvgszJDUOcgz',
  callbackUrl: process.env.NODE_ENV !== 'production' ? 'http://localhost:3000/callback' : 'http://http://localhost:45346/callback',
}
