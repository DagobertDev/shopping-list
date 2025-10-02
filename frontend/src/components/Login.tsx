import { useState } from "react"

function Login() {
    const loginUrl = "http://localhost:5157/login"

    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState("")

    const login = async (e: React.FormEvent) => {
        e.preventDefault()

        if (!email || !password) {
            setError("Please fill in all fields")
            return
        }
        setError("")

        try {
            const response = await fetch(loginUrl, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify({ email, password })
            })

            if (!response.ok) {
                throw new Error("Invalid credentials")
            }

            const data = await response.json()

            localStorage.setItem("AccessToken", data.access_token)

            console.log("Login successful")

        } catch (error) {
            setError(error instanceof Error ? error.message : "Login failed")
        }
    }

    return (
        <>
            <h1>Login</h1>
            <form onSubmit={login}>
                {error && <div style={{ color: 'red' }}>{error}</div>}

                <label htmlFor="email">Email:</label>
                <input
                    id="email"
                    type="email"
                    value={email}
                    onChange={e => setEmail(e.target.value)}
                    required
                />

                <label htmlFor="password">Password:</label>
                <input
                    id="password"
                    type="password"
                    value={password}
                    onChange={e => setPassword(e.target.value)}
                    required
                />

                <button type="submit">Login</button>
            </form>
        </>
    )
}

export default Login
