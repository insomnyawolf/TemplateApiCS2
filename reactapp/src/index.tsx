import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import reportWebVitals from './reportWebVitals'
import { Main, mainRoutes} from './components/main/main'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import ErrorPage from './components/error/error'
import Login from './components/login/login'
import App from './app/App'

import {
  OpenAPI,
} from './services/openapi';

OpenAPI.BASE = "http://localhost:5000";

const root = ReactDOM.createRoot(document.getElementById('root') as HTMLElement)

const router = createBrowserRouter([
  {
    path: '/',
    element: <App />,
    errorElement: <ErrorPage />,
  },
  {
    path: '/login',
    element: <Login />,
    errorElement: <ErrorPage />,
  },
  {
    path: '/projects',
    element: <Main />,
    children: mainRoutes
  },
])

root.render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
)

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals()
