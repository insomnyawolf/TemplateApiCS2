import {
  Form,
} from 'react-router-dom'

export function LogOut () {
  return (
    <>
      <Form action='/'>
        <button type='submit'>Logout</button>
      </Form>
    </>
  )
}

export default LogOut
