Param(
[string]$apiUrl
)

Write-Output "Api Url value from ADO was passed as an Argument in the ADO Task called `$env:REACT_APP_API_URL`
to sauceUserName variable in the Posh. This is the value found=>$apiUrl"

[Environment]::SetEnvironmentVariable("REACT_APP_API_URL", "$apiUrl", "User")