import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

import { fileURLToPath, URL } from 'node:url';

import fs from 'fs';
import path from 'path';
import child_process from 'child_process';

const baseFolder =
    process.env.APPDATA !== undefined && process.env.APPDATA !== ''
        ? `${process.env.APPDATA}/ASP.NET/https`
        : `${process.env.HOME}/.aspnet/https`;

const certificateName = "polyglot.client";
const certFilePath = path.join(baseFolder, `${certificateName}.pem`);

const keyFilePath = path.join(baseFolder, `${certificateName}.key`);

if (!fs.existsSync(certFilePath) || !fs.existsSync(keyFilePath)) {
  if (0 !== child_process.spawnSync('dotnet', [
    'dev-certs',
    'https',
    '--export-path',
    certFilePath,
    '--format',
    'Pem',
    '--no-password',
  ], { stdio: 'inherit', }).status) {
    throw new Error("Could not create certificate.");
  }
}

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url))
    }
  },
  server: {
    proxy: {
      '^/weatherforecast': {
        target: 'https://localhost:7264/',
        secure: false
      },
      '^/ping-auth': {
        target: 'https://localhost:7264/',
        secure: false
      },
      '^/login': {
        target: 'https://localhost:7264/',
        secure: false
      },
      '^/logout': {
        target: 'https://localhost:7264/',
        secure: false
      },
      '^/signin-oidc': {
        target: 'https://localhost:7264/',
        secure: false,
      },
      '^/signout-callback-oidc': {
        target: 'https://localhost:7264/',
        secure: false,
      },
    },
    port: 5173,
    strictPort: true,
    https: {
      key: fs.readFileSync(keyFilePath),
      cert: fs.readFileSync(certFilePath),
    }
  }
})
