import { Form, useRouteError } from 'react-router-dom'

function ErrorPage () {
  const error = useRouteError()

  console.error(error)

  const errorString = JSON.stringify(error, null, '\t')
  return (
    <>
    <div id='error-page'>
        <h1>Oops!</h1>
        <pre>{errorString}</pre>
      </div>
      <Form action='/'>
        <button type='submit'>Go Back To Home</button>
      </Form>
      
    </>
  )
}

export default ErrorPage
