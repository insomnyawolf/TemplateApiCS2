import {
  Link,
  Outlet,
  RouteObject
} from 'react-router-dom'
import ErrorPage from '../error/error'
import RouterTest from '../router-test/RouterTest'
import LogOut from '../login/logout'

export const mainRoutes: Array<RouteObject> = [
  {
    path: 'test',
    element: <RouterTest />
  },
  {
    path: 'error',
    element: <ErrorPage />,
  },
  {
    path: 'logout',
    element: <LogOut />,
  }
]

export function Main () {
  return (
    <>
      <NavBar />
      <Outlet />
    </>
  )
}

function NavBar () {
  return (
    <nav id='nav'>
      <ul>
        {mainRoutes.map(route => {
          return (
            <li key={route.path}>
              <Link to={route.path ?? ''}>{route.path}</Link>
            </li>
          )
        })}
      </ul>
    </nav>
  )
}

export default Main
