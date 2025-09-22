# Chaplin - Distributed URL Shortener

A production-ready URL shortening service built with .NET microservices architecture, demonstrating modern DevOps practices and distributed system design patterns.

## 🎯 Project Overview

This project showcases the development and deployment of a scalable, distributed URL shortening service similar to bit.ly or tinyurl. The focus is on demonstrating microservices architecture, containerization, orchestration, and comprehensive DevOps practices.

**🌐 Live Demo**: https://chaplin.yourdomain.com *(Will be updated with actual subdomain)*
**📊 Monitoring Dashboard**: https://monitoring-chaplin.yourdomain.com
**📚 API Documentation**: https://api-chaplin.yourdomain.com/swagger

> **Note for Recruiters**: This is a fully functional, production-deployed system demonstrating real-world DevOps practices and distributed architecture patterns.

## 🏗️ Architecture

```
┌─────────────────┐    ┌─────────────────┐    ┌─────────────────┐
│   Web Client    │    │   Mobile App    │    │   API Client    │
└─────────┬───────┘    └─────────┬───────┘    └─────────┬───────┘
          │                      │                      │
          └──────────────────────┼──────────────────────┘
                                 │
                    ┌─────────────┴─────────────┐
                    │      API Gateway          │
                    │    (nginx/Traefik)        │
                    └─────────────┬─────────────┘
                                  │
          ┌───────────────────────┼───────────────────────┐
          │                       │                       │
    ┌─────▼─────┐         ┌───────▼───────┐       ┌──────▼──────┐
    │  URL      │         │  Analytics    │       │   User      │
    │ Shortener │         │   Service     │       │ Management  │
    │ Service   │         └───────────────┘       │  Service    │
    └───────────┘                                 └─────────────┘
          │                       │                       │
    ┌─────▼─────┐         ┌───────▼───────┐       ┌──────▼──────┐
    │PostgreSQL │         │    Redis      │       │PostgreSQL  │
    │ (Primary) │         │  (Cache)      │       │ (Users)     │
    └───────────┘         └───────────────┘       └─────────────┘
```

## 📋 Development Roadmap

### Phase 1: MVP (Week 1-2) ✅ = Completed, 🔄 = In Progress, ⏳ = Planned

#### Core Services
- [ ] 🔄 **URL Shortener Service**
  - [ ] 🔄 Create short URL endpoint
  - [ ] 🔄 Redirect endpoint
  - [ ] 🔄 Basic URL validation
  - [ ] 🔄 PostgreSQL integration
  - [ ] 🔄 Base62 encoding for short codes

- [ ] 🔄 **Basic API Gateway**
  - [ ] 🔄 nginx configuration
  - [ ] 🔄 Route requests to services
  - [ ] 🔄 Basic CORS handling

#### Infrastructure
- [ ] ⏳ **Containerization**
  - [ ] ⏳ Dockerfile for each service
  - [ ] ⏳ Docker Compose setup
  - [ ] ⏳ Local development environment

- [ ] ⏳ **Database**
  - [ ] ⏳ PostgreSQL setup
  - [ ] ⏳ Database migrations
  - [ ] ⏳ Connection pooling

- [ ] ⏳ **Domain Setup**
  - [ ] ⏳ DNS configuration for subdomain
  - [ ] ⏳ SSL certificate setup
  - [ ] ⏳ CDN configuration (optional)

#### Deployment
- [ ] ⏳ **Basic CI/CD**
  - [ ] ⏳ GitHub Actions workflow
  - [ ] ⏳ Automated testing
  - [ ] ⏳ Container image building
  - [ ] ⏳ Auto-deploy to staging subdomain

### Phase 2: Enhanced Features (Week 3-4)

#### Services Enhancement
- [ ] ⏳ **Analytics Service**
  - [ ] ⏳ Click tracking
  - [ ] ⏳ Basic statistics API
  - [ ] ⏳ Redis caching
  - [ ] ⏳ Async event processing

- [ ] ⏳ **User Management Service**
  - [ ] ⏳ User registration/login
  - [ ] ⏳ JWT authentication
  - [ ] ⏳ User-owned URLs
  - [ ] ⏳ Basic authorization

#### Infrastructure
- [ ] ⏳ **Caching Layer**
  - [ ] ⏳ Redis implementation
  - [ ] ⏳ Cache-aside pattern
  - [ ] ⏳ Cache invalidation strategy

- [ ] ⏳ **Message Queue**
  - [ ] ⏳ RabbitMQ/Redis Pub/Sub
  - [ ] ⏳ Async analytics processing
  - [ ] ⏳ Event-driven architecture

### Phase 3: Production Ready (Week 5-6)

#### Reliability & Performance
- [ ] ⏳ **Health Checks**
  - [ ] ⏳ Service health endpoints
  - [ ] ⏳ Database connectivity checks
  - [ ] ⏳ Dependency health monitoring

- [ ] ⏳ **Error Handling**
  - [ ] ⏳ Global exception handling
  - [ ] ⏳ Circuit breaker pattern
  - [ ] ⏳ Retry policies
  - [ ] ⏳ Graceful degradation

- [ ] ⏳ **Rate Limiting**
  - [ ] ⏳ IP-based rate limiting
  - [ ] ⏳ User-based quotas
  - [ ] ⏳ Distributed rate limiting

#### Security
- [ ] ⏳ **API Security**
  - [ ] ⏳ Input validation
  - [ ] ⏳ SQL injection protection
  - [ ] ⏳ XSS protection
  - [ ] ⏳ HTTPS enforcement

- [ ] ⏳ **Authentication & Authorization**
  - [ ] ⏳ JWT token validation
  - [ ] ⏳ Role-based access control
  - [ ] ⏳ API key management

### Phase 4: Cloud Deployment (Week 7-8)

#### Container Orchestration
- [ ] ⏳ **Kubernetes Setup**
  - [ ] ⏳ DigitalOcean Kubernetes cluster
  - [ ] ⏳ Deployment manifests
  - [ ] ⏳ Service definitions
  - [ ] ⏳ ConfigMaps and Secrets

- [ ] ⏳ **Ingress & Load Balancing**
  - [ ] ⏳ Ingress controller setup
  - [ ] ⏳ TLS/SSL certificates (Let's Encrypt)
  - [ ] ⏳ Load balancer configuration
  - [ ] ⏳ Custom domain routing
  - [ ] ⏳ Production deployment to main subdomain

#### Database Management
- [ ] ⏳ **Managed Databases**
  - [ ] ⏳ DigitalOcean Managed PostgreSQL
  - [ ] ⏳ Redis cluster setup
  - [ ] ⏳ Database backups
  - [ ] ⏳ Connection pooling optimization

### Phase 5: Monitoring & Observability (Week 9-10)

#### Monitoring Stack
- [ ] ⏳ **Metrics Collection**
  - [ ] ⏳ Prometheus setup
  - [ ] ⏳ Custom metrics implementation
  - [ ] ⏳ Business metrics tracking

- [ ] ⏳ **Visualization**
  - [ ] ⏳ Grafana dashboards
  - [ ] ⏳ Service performance metrics
  - [ ] ⏳ Infrastructure monitoring
  - [ ] ⏳ Business intelligence dashboards

- [ ] ⏳ **Logging**
  - [ ] ⏳ Centralized logging (ELK/Loki)
  - [ ] ⏳ Structured logging
  - [ ] ⏳ Log aggregation and search

#### Alerting
- [ ] ⏳ **Alert Rules**
  - [ ] ⏳ Service availability alerts
  - [ ] ⏳ Performance degradation alerts
  - [ ] ⏳ Error rate thresholds
  - [ ] ⏳ Resource utilization alerts

### Phase 6: Advanced Features (Week 11-12)

#### Performance Optimization
- [ ] ⏳ **Caching Strategies**
  - [ ] ⏳ Multi-level caching
  - [ ] ⏳ CDN integration
  - [ ] ⏳ Cache warming strategies

- [ ] ⏳ **Database Optimization**
  - [ ] ⏳ Read replicas
  - [ ] ⏳ Database sharding strategy
  - [ ] ⏳ Query optimization

#### Advanced DevOps
- [ ] ⏳ **Service Mesh**
  - [ ] ⏳ Istio/Linkerd implementation
  - [ ] ⏳ Traffic management
  - [ ] ⏳ Security policies
  - [ ] ⏳ Observability features

- [ ] ⏳ **Advanced Deployment**
  - [ ] ⏳ Blue-green deployments
  - [ ] ⏳ Canary releases
  - [ ] ⏳ Feature flags
  - [ ] ⏳ Rollback strategies

### Phase 7: Polish & Documentation (Week 13+)

#### User Experience
- [ ] ⏳ **Frontend Application**
  - [ ] ⏳ React/Blazor web application
  - [ ] ⏳ User dashboard
  - [ ] ⏳ Analytics visualization
  - [ ] ⏳ Custom domain support

#### Documentation
- [ ] ⏳ **API Documentation**
  - [ ] ⏳ OpenAPI/Swagger specs
  - [ ] ⏳ Interactive API explorer
  - [ ] ⏳ Code examples

- [ ] ⏳ **Operations Documentation**
  - [ ] ⏳ Deployment guides
  - [ ] ⏳ Troubleshooting guides
  - [ ] ⏳ Architecture decision records

## 🌍 Live Deployment Strategy

### Domain Structure
```
yourdomain.com (your main domain)
├── short.yourdomain.com          # Main URL shortener service
├── api.yourdomain.com            # API Gateway & Documentation
├── monitoring.yourdomain.com     # Grafana dashboards
├── staging.yourdomain.com        # Staging environment
└── dev.yourdomain.com           # Development environment (optional)
```

### Environment Progression
- **Development**: Local Docker Compose
- **Staging**: `staging.yourdomain.com` - Auto-deployed from `develop` branch
- **Production**: `short.yourdomain.com` - Deployed from `main` branch

### SSL & Security
- Let's Encrypt certificates for all subdomains
- HTTPS enforcement
- HSTS headers
- Security headers (CSP, X-Frame-Options, etc.)

## 🛠️ Technology Stack

### Backend Services
- **Framework**: .NET 8 (ASP.NET Core Web API)
- **Databases**: PostgreSQL (primary), Redis (cache)
- **Message Queue**: RabbitMQ or Redis Pub/Sub
- **Authentication**: JWT tokens

### DevOps & Infrastructure
- **Containerization**: Docker
- **Orchestration**: Kubernetes
- **CI/CD**: GitHub Actions
- **Cloud Provider**: DigitalOcean
- **Monitoring**: Prometheus + Grafana
- **Logging**: Structured logging with Serilog
- **API Gateway**: nginx or Traefik

### Development Tools
- **IDE**: Visual Studio / VS Code
- **API Testing**: Postman/Swagger
- **Load Testing**: k6 or NBomber
- **Code Quality**: SonarCloud

## 🚀 Quick Start

### Prerequisites
- Docker & Docker Compose
- .NET 8 SDK
- PostgreSQL (or Docker)
- Git

### Local Development Setup

```bash
# Clone the repository
git clone https://github.com/yourusername/distributed-url-shortener.git
cd distributed-url-shortener

# Start infrastructure services
docker-compose up -d postgres redis

# Run migrations
dotnet ef database update --project src/UrlShortener.Data

# Start services
dotnet run --project src/UrlShortener.Api
dotnet run --project src/Analytics.Api
dotnet run --project src/UserManagement.Api
```

### Production Deployment

```bash
# Deploy to staging
git push origin develop

# Deploy to production
git push origin main

# Or manual Kubernetes deployment
kubectl apply -f k8s/production/
```

### Custom Domain Setup

1. **DNS Configuration**:
```bash
# A records pointing to your load balancer
short.yourdomain.com    -> YOUR_LOAD_BALANCER_IP
api.yourdomain.com      -> YOUR_LOAD_BALANCER_IP
monitoring.yourdomain.com -> YOUR_LOAD_BALANCER_IP
```

2. **SSL Certificate**:
```yaml
# cert-manager will handle Let's Encrypt automatically
apiVersion: cert-manager.io/v1
kind: ClusterIssuer
metadata:
  name: letsencrypt-prod
spec:
  acme:
    server: https://acme-v02.api.letsencrypt.org/directory
    email: your-email@yourdomain.com
```

## 📊 Key Metrics & KPIs

- **Performance**: < 100ms response time for URL redirects
- **Availability**: 99.9% uptime SLA
- **Scale**: Handle 1000+ requests/second
- **Storage**: Support 1M+ URLs
- **Global**: CDN response time < 50ms

## 🔗 Production URLs

- **Main Service**: https://short.yourdomain.com
- **API Documentation**: https://api.yourdomain.com/swagger
- **Health Checks**: https://api.yourdomain.com/health
- **Metrics**: https://monitoring.yourdomain.com
- **Staging Environment**: https://staging.yourdomain.com

> Replace `yourdomain.com` with your actual domain

## 🧪 Testing Strategy

- **Unit Tests**: xUnit for business logic
- **Integration Tests**: TestContainers for database tests
- **Load Tests**: k6 for performance testing
- **E2E Tests**: Automated API testing

## 📈 Monitoring Dashboards

- Service health and performance
- Business metrics (URLs created, clicks)
- Infrastructure metrics (CPU, memory, network)
- Error rates and latency percentiles

## 🔧 Configuration Management

- Environment-specific configurations
- Kubernetes ConfigMaps and Secrets
- Feature flags for gradual rollouts

## 📝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Project Status**: 🚧 In Development

**Current Phase**: Phase 1 - MVP Development

**Next Milestone**: Basic URL shortening functionality with containerized deployment