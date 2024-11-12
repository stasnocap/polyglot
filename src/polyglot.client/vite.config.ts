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
      '^/api/.*': {
        target: 'http://localhost:5000/',
        secure: false,
      },
      '^/signin-oidc': {
        target: 'http://localhost:5000/',
        secure: false,
      },
      '^/signout-callback-oidc': {
        target: 'http://localhost:5000/',
        secure: false,
      },
    },
    port: 5173,
    strictPort: true,
    host: true,
    // https: {
    //   key: fs.readFileSync(keyFilePath),
    //   cert: fs.readFileSync(certFilePath),
    // }
  }
})
