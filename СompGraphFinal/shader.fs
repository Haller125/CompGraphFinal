#version 430 core
in vec3 normal;
in vec3 FragPos;
out vec4 FragColor;

uniform mat4 view;

vec3 lightPos = vec3(0, 1, 0);
vec3 lightColor = vec3(1); 
vec3 objectColor = vec3(1, 0, 0);

void main()
{
	float ambientStrength = 0.1;
	vec3 ambient = ambientStrength * lightColor;
	
	vec3 norm = normalize(normal);
	vec3 lightDir = normalize(lightPos - FragPos);
	float diff = max(dot(norm, lightDir), 0.0);
	vec3 diffuse = diff * lightColor;

	vec3 result = (diffuse + ambient) * objectColor;
	FragColor = vec4(result, 1.0);
}