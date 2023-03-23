import {
  Form,
} from 'react-router-dom'

export function Login () {
  return (
    <>
      <Form action='/projects'>
        <button type='submit'>Sucessful Login Button</button>
      </Form>
    </>
  )
}

export default Login
